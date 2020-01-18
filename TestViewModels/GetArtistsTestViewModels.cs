 namespace TestViewModels
{ 
    using Artity.Services.Data.ServiceModels;
    using Artity.Services.Mapping;
    using System;

    public class GetArtistsTestViewModels : IMapFrom<ArtistServiceModel>, IComparable
    {
        public string Nikname { get; set; }

        public int CompareTo(object obj)
        {
            var myprops = typeof(GetArtistsTestViewModels).GetProperties().Length;

            var objProp = obj.GetType().GetProperties().Length;

            if(myprops != objProp)
            {
                return -1;
            }

            return 0;
        }
    }

 
}
