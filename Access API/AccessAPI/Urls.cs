namespace Access_API
{
    public static class Urls
    {
        public const string FileTransferUrl = "http://knox-master01.srv.aau.dk/fileAPI";
        // public const string SearchUrl = "http://knox-master01.srv.aau.dk/searchAPI"; // Not currently in use
        public const string VaUrl = "http://knox-master01.srv.aau.dk/virtualAssistantAPI";
        // below, the double endpoint is needed because of the nginx rerouting service
        public const string DocumentDataUrl = "http://knox-master01.srv.aau.dk/document-data-api/document-data-api";
        public const string RdfUrl = "http://knox-master01.srv.aau.dk/rdfAPI";
    }
}
