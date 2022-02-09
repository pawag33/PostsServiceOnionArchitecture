using System;
using System.Linq;
using ApplicationCore.DomainServices.Interfaces;

namespace ApplicationCore.DomainServices.Implementation
{
    public class ContentModerator : IContentModerator
    {
        private readonly string[] stopWords = {"fuck"};

        public void ModerateContent(string content)
        {
            if(content.ToLower().Split(' ').Intersect(stopWords).Any())
            {
                // TODO: create dedicate exception
                throw new Exception("Content contains a stop word");
            }
        }
    }
}
