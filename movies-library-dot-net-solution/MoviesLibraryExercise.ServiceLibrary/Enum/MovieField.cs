using System.Runtime.Serialization;

namespace MoviesLibraryExercise.ServiceLibrary
{
    [DataContract]
    public enum MovieField
    {
        [EnumMember] Classification,
        [EnumMember] Genre,
        [EnumMember] MovieId,
        [EnumMember] Rating,
        [EnumMember] ReleaseDate,
        [EnumMember] Title,
    };
}