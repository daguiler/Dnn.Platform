﻿
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information

using System;
using System.Data;
using System.Xml.Serialization;

using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities;
using DotNetNuke.Entities.Modules;

namespace DotNetNuke.Services.Social.Messaging
{
    /// -----------------------------------------------------------------------------
    /// Project:    DotNetNuke
    /// Namespace:  DotNetNuke.Entities.Messaging
    /// Class:      MessageRecipient
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The MessageRecipient class is used to store the details of all recipients of a particular message
    /// </summary>
    /// -----------------------------------------------------------------------------
    [Serializable]
    public class MessageRecipient : BaseEntityInfo, IHydratable
    {
        private int _recipientID = -1;

        /// <summary>
        /// RecipientID - The primary key
        /// </summary>
        [XmlAttribute]
        public int RecipientID
        {
            get
            {
                return this._recipientID;
            }
            set
            {
                this._recipientID = value;
            }
        }

        /// <summary>
        /// The messageID of who sent the message to this recipient
        /// </summary>
        [XmlAttribute]
        public int MessageID { get; set; }

        /// <summary>
        /// The UserID of the user receiving the message
        /// </summary>
        [XmlAttribute]
        public int UserID { get; set; }

        /// <summary>
        /// Is Message read. True: Yes, False: No.
        /// </summary>
        [XmlAttribute]
        public bool Read { get; set; }

        /// <summary>
        /// Is Message archived. True: Yes, False: No.
        /// </summary>
        [XmlAttribute]
        public bool Archived { get; set; }

        /// <summary>
        /// IHydratable.KeyID.
        /// </summary>
        [XmlIgnore]
        public int KeyID
        {
            get
            {
                return this.RecipientID;
            }
            set
            {
                this.RecipientID = value;
            }
        }

        /// <summary>
        /// Fill the object with data from database.
        /// </summary>
        /// <param name="dr">the data reader.</param>
        public void Fill(IDataReader dr)
        {
            this.RecipientID = Convert.ToInt32(dr["RecipientID"]);
            this.MessageID = Convert.ToInt32(dr["MessageID"]);
            this.UserID = Convert.ToInt32(dr["UserID"]);
            this.Archived = Null.SetNullBoolean(dr["Archived"]);
            this.Read = Null.SetNullBoolean(dr["Read"]);

            // add audit column data
            this.FillInternal(dr);

        }
    }
}
