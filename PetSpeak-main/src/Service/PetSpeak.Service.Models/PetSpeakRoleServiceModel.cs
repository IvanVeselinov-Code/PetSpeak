﻿namespace PetSpeak.Service.Models
{
    public class PetSpeakRoleServiceModel : MetadataBaseServiceModel
    {
        public const string PetSpeakRoleDefaultAuthority = "User";

        public string Label { get; set; }

        // CSS Color configuration
        public string Color { get; set; }

        public string Authority { get; set; } = PetSpeakRoleDefaultAuthority;
    }
}
