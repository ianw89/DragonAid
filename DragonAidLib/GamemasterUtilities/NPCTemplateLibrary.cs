using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;

namespace DragonAid.Lib.GamemasterUtilities
{
    /// <summary>
    /// Singleton class that loads all NPC Templates from XML and makes them available.
    /// </summary>
    [DataContract]
    [KnownType(typeof(NonPlayerCharacterTemplate))]
    public class NPCTemplateLibrary
    {
        public static readonly NPCTemplateLibrary Instance; 
        private List<NonPlayerCharacterTemplate> _templates;

        /// <summary>
        /// In the static initializer we deserialize the NonPlayerCharacterTemplates and create our singleton.
        /// </summary>
        static NPCTemplateLibrary()
        {
            var assembly = typeof(NPCTemplateLibrary).GetTypeInfo().Assembly;
            var serializer = new DataContractSerializer(typeof(NPCTemplateLibrary));
            var inStream = assembly.GetManifestResourceStream("DragonAid.Lib.NPCTemplates.xml");

            Instance = (NPCTemplateLibrary)serializer.ReadObject(inStream);
        }

        [DataMember]
        public List<NonPlayerCharacterTemplate> Templates
        {
            get { return this._templates ?? (this._templates = new List<NonPlayerCharacterTemplate>()); }
        }
    }
}
