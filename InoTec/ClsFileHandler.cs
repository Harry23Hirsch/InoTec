﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace InoTec
{
    public class ClsFileHandler
    {
        private string _projectPath;

        public ClsFileHandler(string projectPath)
        {
            if (string.IsNullOrEmpty(projectPath))
                throw new ArgumentNullException(nameof(_projectPath));

            if (!Directory.Exists(projectPath))
                throw new DirectoryNotFoundException(nameof(_projectPath));

            _projectPath = projectPath;
        }

        public IEnumerable<IEnumerable<ClsLogFileLineType>> GetClsLogFiles()
        {
            if (string.IsNullOrEmpty(_projectPath))
                throw new ArgumentNullException(nameof(_projectPath));

            if (!Directory.Exists(_projectPath))
                throw new DirectoryNotFoundException(nameof(_projectPath));

            var logFiles = Directory.GetFiles(_projectPath, "*.LOG");
            var result = new List<IEnumerable<ClsLogFileLineType>>();

            foreach (string logFile in logFiles)
            {
                if (!File.Exists(logFile))
                    continue;

                var lineInfo = GetClsLogLineInfo(File.ReadLines(logFile));

                if (lineInfo is null)
                    continue;

                result.Add(lineInfo);
            }

            return result;
        }

        public IEnumerable<ClsLogFileLineType> GetClsLogLineInfo(IEnumerable<string> lines)
        {
            var result = new List<ClsLogFileLineType>();

            var logLines = lines.ToList();

            if (logLines.Count <= 1)
                return null;

            logLines.RemoveAt(1);

            var ym = logLines[0].Trim().TrimStart('<').TrimEnd('>').Split('-');
            var year = ym[0];
            var month = ym[1];
            int monthInt;

            try
            {
                monthInt = int.Parse(month);
            }
            catch
            {
                throw new FormatException();
            }

            if (monthInt <= 9)
                month = $"0{monthInt}";

            for (int i = 1; i < logLines.Count; i++)
            {
                var logLine = logLines[i];
                var tsplit = logLine.Split('>');
                var dateRaw = tsplit[0].Split('.');

                var text = tsplit[1];
                var day = dateRaw[0];
                var time = dateRaw[1].Trim();

                result.Add(new ClsLogFileLineType(
                    year,
                    month,
                    day,
                    time,
                    text));
            }

            return result;
        }

        public IEnumerable<BcsBatStatusInfoType> GetBtLogFiles()
        {
            if (string.IsNullOrEmpty(_projectPath))
                throw new ArgumentNullException(nameof(_projectPath));

            string btPath = String.Format($@"{_projectPath}\BT");

            if (!Directory.Exists(btPath))
                throw new DirectoryNotFoundException();

            var btLogFiles = Directory.GetFiles(btPath, "*.LOG");
            var btLogResult = new List<BcsBatStatusInfoType>();

            foreach (string logFile in btLogFiles)
            {
                if (!File.Exists(logFile))
                    continue;

                var lines = File.ReadLines(logFile).ToList();


                var bcsInfo = DeserializeBcsBat<BatInfo>(lines[0]);
                var btLogLines = new List<BatStatusType>();

                for (int i = 1; i < lines.Count; i++)
                {
                    btLogLines.Add(DeserializeBcsBat<BatStatusType>(lines[i]));
                }

                btLogResult.Add(new BcsBatStatusInfoType(bcsInfo, btLogLines));
            }

            return btLogResult;
        }

        public T DeserializeBcsBat<T>(string json)
        {
            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };

            return JsonSerializer.Deserialize<T>(json, serializeOptions);
        }

        public IEnumerable<ClsFaultInfoType> GetClsFaultInfos()
        {
            if (string.IsNullOrEmpty(_projectPath))
                throw new ArgumentNullException(nameof(_projectPath));

            if (!Directory.Exists(_projectPath))
                throw new DirectoryNotFoundException(nameof(_projectPath));

            var files = Directory.GetFiles(_projectPath, "*.txt");
            var clsFiles = GetClsFaultInfoFiles(files);

            var clsFaultResult = new List<ClsFaultInfoType>();
            foreach (string clsFile in clsFiles)
            {
                var cls = ParseClsFaultInfoFile(clsFile);

                if (cls == null)
                    continue;

                clsFaultResult.Add(cls);
            }


            return clsFaultResult;
        }

        public IEnumerable<string> GetClsFaultInfoFiles(string[] files)
        {
            var clsFiles = new List<string>();

            foreach (var file in files)
            {
                var fileName = Path.GetFileName(file);
                if (!fileName.StartsWith("CLS_Fault_Info"))
                    continue;

                clsFiles.Add(file);
            }

            return clsFiles;
        }

        public ClsFaultInfoType ParseClsFaultInfoFile(string fileName)
        {
            if (!File.Exists(fileName))
                throw new FileNotFoundException(nameof(fileName));

            var lines = File.ReadLines(fileName).ToList();

            var geraeteInfo = new List<string>();
            int i = 1;
            
            while (!string.IsNullOrEmpty(lines[i]))
            {
                geraeteInfo.Add(lines[i]);
                i++;
            }

            i++;

            var stromkreise = lines[i+1];
            var leuchtenInfo = new List<ClsLightFaultInfoType>();

            if (!stromkreise.Equals("Keine Fehler"))
            {
                i++;
                while (!string.IsNullOrEmpty(lines[i]))
                {

                    var pLine = ParseClsLightFault(lines[i]);
                    if (pLine == null)
                    {
                        i++;
                        continue;
                    }

                    leuchtenInfo.Add(pLine);

                    i++;
                }
            }
            else
            {
                i += 2;
            }

            i++;

            var batterie = lines[i+1];
            var batterieInfo = new List<string>();

            if (!batterie.Equals("Keine Fehler"))
            {
                i++;

                while (!string.IsNullOrEmpty(lines[i]))
                {
                    batterieInfo.Add(lines[i]);
                    i++;
                }
            }
            else
            {
                i += 2;
            }

            i++;

            var externe = lines[i+1];
            var externeInfo = new List<string>();
            if (!externe.Equals("Keine Fehler"))
            {
                i++;

                while (!string.IsNullOrEmpty(lines[i]))
                {
                    externeInfo.Add(lines[i]);
                    i++;
                }
            }
            else
            {
                i += 2;
            }

            return new ClsFaultInfoType(geraeteInfo, leuchtenInfo, batterieInfo, externeInfo);
        }

        public ClsLightFaultInfoType ParseClsLightFault(string line)
        {
            if (string.IsNullOrEmpty(line)) 
                return null;

            var sLine = line.Split(' ');

            if (sLine[1].Equals("Stromkreis"))
                return null;

            var f = sLine[2].TrimEnd(';').Split('.');
            var cls = f[0];
            var slot = f[1];
            var adr = sLine[3];
            var text = sLine[0];

            return new ClsLightFaultInfoType(int.Parse(cls), int.Parse(slot), int.Parse(adr), text);
        }
    }
}
