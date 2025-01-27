﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.IO;
using InterGraph_Labo8.Properties;
using System.Windows;
using System.Collections;


namespace FileExplorer.Model
{
    /// <summary>
    /// Enum to hold the Types of different file objects
    /// </summary>
    public enum ObjectType
    {
        MyComputer = 0,
        DiskDrive = 1,
        Directory = 2,
        File = 3
    }

    /// <summary>
    /// Class for containing the information about a Directory/File
    /// </summary>
    public class DirInfo //: DependencyObject
    {
        #region // Public Properties
        public string Name { get; set; }
        public string Path { get; set; }
        public string Root { get; set; }
        public string Size { get; set; }
        public string Ext { get; set; }
        public int DirType { get; set; }
        public IList<DirInfo> SubDirectories;
        #endregion

     
        #region // .ctor(s)
        public DirInfo()
        {
            SubDirectories = new List<DirInfo>();
            SubDirectories.Add(new DirInfo("TempDir"));
        }

        public DirInfo(string directoryName)
        {
            Name = directoryName;
        }

        public DirInfo(DirectoryInfo dir)
            : this()
        {
            Name = dir.Name;
            Root = dir.Root.Name;
            Path = dir.FullName;
            DirType = (int)ObjectType.Directory;
        }

        public DirInfo(FileInfo fileobj)
        {
            Name = fileobj.Name;
            Path = fileobj.FullName;
            DirType = (int)ObjectType.File;
            Size = (fileobj.Length / 1024).ToString() + " KB";
            Ext = fileobj.Extension + " File";
        }

        public DirInfo(DriveInfo driveobj)
            : this()
        {
            if (driveobj.Name.EndsWith(@"\"))
                Name = driveobj.Name.Substring(0, driveobj.Name.Length - 1);
            else
                Name = driveobj.Name;

            Path = driveobj.Name;
            DirType = (int)ObjectType.DiskDrive;
        } 
        #endregion
    }
}
