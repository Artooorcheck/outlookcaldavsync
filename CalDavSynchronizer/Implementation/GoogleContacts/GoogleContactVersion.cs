﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CalDavSynchronizer.Implementation.GoogleContacts
{
    public class GoogleContactVersion
    {
        [XmlAttribute("c")]
        public string ContactEtag { get; set; }

        [XmlAttribute("p")]
        public string PhotoEtag { get; set; } // currently usage of PhotoEtag is not required, since changing the photo also updates the etag of the contact 
    }
}