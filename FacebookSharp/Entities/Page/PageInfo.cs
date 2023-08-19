using Newtonsoft.Json;

namespace FacebookSharp.Entities.Page
{
    public class PageInfo
    {
        [JsonProperty("birthday")]
        public string Birthday { get; set; }

        [JsonProperty("business")]
        public Business Business { get; set; }

        [JsonProperty("can_checkin")]
        public bool? CanCheckin { get; set; }

        [JsonProperty("can_post")]
        public bool? CanPost { get; set; }

        [JsonProperty("checkins")]
        public int? Checkins { get; set; }

        [JsonProperty("connected_instagram_account")]
        public ConnectedInstagramAccount ConnectedInstagramAccount { get; set; }

        [JsonProperty("connected_page_backed_instagram_account")]
        public ConnectedPageBackedInstagramAccount ConnectedPageBackedInstagramAccount { get; set; }

        [JsonProperty("cover")]
        public Cover Cover { get; set; }

        [JsonProperty("about")]
        public string About { get; set; }

        [JsonProperty("display_subtext")]
        public string DisplaySubtext { get; set; }

        [JsonProperty("displayed_message_response_time")]
        public string DisplayedMessageResponseTime { get; set; }

        [JsonProperty("emails")]
        public List<string> Emails { get; set; }

        [JsonProperty("fan_count")]
        public int? FanCount { get; set; }

        [JsonProperty("followers_count")]
        public int? FollowersCount { get; set; }

        [JsonProperty("global_brand_page_name")]
        public string GlobalBrandPageName { get; set; }

        [JsonProperty("has_transitioned_to_new_page_experience")]
        public bool? HasTransitionedToNewPageExperience { get; set; }

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("category_list")]
        public List<CategoryList> CategoryList { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("instagram_business_account")]
        public InstagramBusinessAccount InstagramBusinessAccount { get; set; }

        [JsonProperty("is_always_open")]
        public bool? IsAlwaysOpen { get; set; }

        [JsonProperty("is_community_page")]
        public bool? IsCommunityPage { get; set; }

        [JsonProperty("is_eligible_for_branded_content")]
        public bool? IsEligibleForBrandedContent { get; set; }

        [JsonProperty("is_messenger_bot_get_started_enabled")]
        public bool? IsMessengerBotGetStartedEnabled { get; set; }

        [JsonProperty("is_messenger_platform_bot")]
        public bool? IsMessengerPlatformBot { get; set; }

        [JsonProperty("is_owned")]
        public bool? IsOwned { get; set; }

        [JsonProperty("is_permanently_closed")]
        public bool? IsPermanentlyClosed { get; set; }

        [JsonProperty("is_published")]
        public bool? IsPublished { get; set; }

        [JsonProperty("is_unclaimed")]
        public bool? IsUnclaimed { get; set; }

        [JsonProperty("is_webhooks_subscribed")]
        public bool? IsWebhooksSubscribed { get; set; }

        [JsonProperty("leadgen_tos_accepted")]
        public bool? LeadgenTosAccepted { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("merchant_review_status")]
        public string MerchantReviewStatus { get; set; }

        [JsonProperty("messaging_feature_status")]
        public MessagingFeatureStatus MessagingFeatureStatus { get; set; }

        [JsonProperty("messenger_ads_default_icebreakers")]
        public List<string> MessengerAdsDefaultIcebreakers { get; set; }

        [JsonProperty("messenger_ads_quick_replies_type")]
        public string MessengerAdsQuickRepliesType { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("name_with_location_descriptor")]
        public string NameWithLocationDescriptor { get; set; }

        [JsonProperty("page_token")]
        public string PageToken { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("place_type")]
        public string PlaceType { get; set; }

        [JsonProperty("promotion_eligible")]
        public bool? PromotionEligible { get; set; }

        [JsonProperty("rating_count")]
        public int? RatingCount { get; set; }

        [JsonProperty("single_line_address")]
        public string SingleLineAddress { get; set; }

        [JsonProperty("supports_donate_button_in_live_video")]
        public bool? SupportsDonateButtonInLiveVideo { get; set; }

        [JsonProperty("talking_about_count")]
        public int? TalkingAboutCount { get; set; }

        [JsonProperty("temporary_status")]
        public string TemporaryStatus { get; set; }

        [JsonProperty("unread_message_count")]
        public int? UnreadMessageCount { get; set; }

        [JsonProperty("unread_notif_count")]
        public int? UnreadNotifCount { get; set; }

        [JsonProperty("unseen_message_count")]
        public int? UnseenMessageCount { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("verification_status")]
        public string VerificationStatus { get; set; }

        [JsonProperty("voip_info")]
        public VoipInfo VoipInfo { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("were_here_count")]
        public int? WereHereCount { get; set; }
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        

    }
    public class Business
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class CategoryList
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class ConnectedInstagramAccount
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class ConnectedPageBackedInstagramAccount
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class Cover
    {
        [JsonProperty("cover_id")]
        public string CoverId { get; set; }

        [JsonProperty("offset_x")]
        public int? OffsetX { get; set; }

        [JsonProperty("offset_y")]
        public int? OffsetY { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class InstagramBusinessAccount
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class Location
    {
        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("latitude")]
        public double? Latitude { get; set; }

        [JsonProperty("longitude")]
        public double? Longitude { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }
    }

    public class MessagingFeatureStatus
    {
        [JsonProperty("hop_v2")]
        public bool? HopV2 { get; set; }
    }
    public class VoipInfo
    {
        [JsonProperty("has_permission")]
        public bool? HasPermission { get; set; }

        [JsonProperty("has_mobile_app")]
        public bool? HasMobileApp { get; set; }

        [JsonProperty("is_pushable")]
        public bool? IsPushable { get; set; }

        [JsonProperty("is_callable")]
        public bool? IsCallable { get; set; }

        [JsonProperty("is_callable_webrtc")]
        public bool? IsCallableWebrtc { get; set; }

        [JsonProperty("reason_code")]
        public int? ReasonCode { get; set; }

        [JsonProperty("reason_description")]
        public string ReasonDescription { get; set; }
    }
}
