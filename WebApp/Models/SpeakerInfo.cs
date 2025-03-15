using System.Text.Json.Serialization;

namespace WebApp.Models;

public partial class SpeakerInfo
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("firstName")]
    public string FirstName { get; set; }

    [JsonPropertyName("lastName")]
    public string LastName { get; set; }

    [JsonPropertyName("fullName")]
    public string FullName { get; set; }

    [JsonPropertyName("bio")]
    public string Bio { get; set; }

    [JsonPropertyName("tagLine")]
    public string TagLine { get; set; }

    [JsonPropertyName("profilePicture")]
    public Uri ProfilePicture { get; set; }

    [JsonPropertyName("sessions")]
    public List<SpeakerSession> Sessions { get; set; }

    [JsonPropertyName("isTopSpeaker")]
    public bool IsTopSpeaker { get; set; }

    [JsonPropertyName("links")]
    public List<Link> Links { get; set; }

    [JsonPropertyName("questionAnswers")]
    public List<object> QuestionAnswers { get; set; }

    [JsonPropertyName("categories")]
    public List<object> Categories { get; set; }


    public string SpeakerUrl()
    {
        var bio = this.Links.SingleOrDefault(xx => xx.LinkType == "Sessionize");
        if (bio is null) bio = this.Links.SingleOrDefault(xx => xx.LinkType == "Linkedin");
        if (bio is null) bio = this.Links.FirstOrDefault();
        if (bio is null) return string.Empty;
        return bio.Url;
    }

}

public partial class Link
{
    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("linkType")]
    public string LinkType { get; set; }
}

public enum LinkType { Blog, Facebook, Instagram, LinkedIn, Sessionize, Twitter, XTwitter };

public partial class SpeakerSession
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }
}