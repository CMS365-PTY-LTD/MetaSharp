namespace MetaSharp.Source
{
    public struct Constants
    {
        public struct GraphAPI
        {
            public const string URL = "https://graph.facebook.com";
            public const string VERSION = "v18.0";
            public struct Page
            {
                public struct Fields
                {
                    public const string ME = "birthday,business,can_checkin,can_post,checkins,connected_instagram_account,connected_page_backed_instagram_account,cover,about,display_subtext,displayed_message_response_time" +
                    ",emails" +",fan_count,followers_count,global_brand_page_name,has_transitioned_to_new_page_experience,access_token,ad_campaign,affiliation,app_id,artists_we_like,attire,awards,band_interests" +
                    ",band_members,bio,booking_agent,built,category,category_list,company_overview,contact_address,copyright_whitelisted_ig_partners,country_page_likes,culinary_team,current_location" +
                    ",delivery_and_pickup_option_info,description,description_html,differently_open_offerings,directed_by,engagement,featured_video,features,food_styles,founded,general_info,general_manager,genre" +
                    ",global_brand_root_id,has_added_app,has_whatsapp_business_number,has_whatsapp_number,hometown,hours,id,impressum,influences,instagram_business_account,is_always_open,is_chain,is_community_page,is_eligible_for_branded_content" +
                    ",is_messenger_bot_get_started_enabled,is_messenger_platform_bot,is_owned,is_permanently_closed,is_published,is_unclaimed,is_webhooks_subscribed,leadgen_tos_acceptance_time,leadgen_tos_accepted" +
                    ",leadgen_tos_accepting_user,link,location,members,merchant_review_status,messaging_feature_status,messenger_ads_default_icebreakers,messenger_ads_default_page_welcome_message" +
                    ",messenger_ads_default_quick_replies,messenger_ads_quick_replies_type,mission,mpg,name,name_with_location_descriptor,network,new_like_count,offer_eligible,overall_star_rating,page_token,parking" +
                    ",payment_options,personal_info,personal_interests,pharma_safety_info,phone,pickup_options,place_type,plot_outline,preferred_audience,press_contact,price_range,privacy_info_url,produced_by,products" +
                    ",promotion_eligible,promotion_ineligible_reason,public_transit,rating_count,record_label,release_date,restaurant_services,restaurant_specialties,schedule,screenplay_by,season,single_line_address" +
                    ",starring,start_info,store_code,store_location_descriptor,store_number,studio,supports_donate_button_in_live_video,talking_about_count,temporary_status,unread_message_count,unread_notif_count" +
                    ",unseen_message_count,username,verification_status,voip_info,website,were_here_count,whatsapp_number,written_by";
                    public const string ALBUMS = "backdated_time,backdated_time_granularity,can_upload,count,cover_photo,created_time,description,event,from,id,link,location,name,place,privacy,type,updated_time" +
                    ",picture{cache_key,height,is_silhouette,url,width}";
                }
            }
        }
    }
}
