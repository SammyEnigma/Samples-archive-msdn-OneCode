﻿/****************************** Module Header ******************************\
* Module Name:	Story.cs
* Project:		StoryDataModel
* Copyright (c) Microsoft Corporation.
* 
* A model class representing a story.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using Microsoft.WindowsAzure.StorageClient;

namespace StoryDataModel
{
    public sealed class Story : TableServiceEntity
    {
        public Story()
        {
        }

        public Story(string id, string name, string videoUri)
        {
            this.PartitionKey = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString();
            this.RowKey = id;
            this.Name = name;
            this.VideoUri = videoUri;
        }

        public string Name { get; set; }
        public string VideoUri { get; set; }
    }
}
