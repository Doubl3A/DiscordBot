import Icons from "@/values/Enum/Icons";
import ISite from "@/interfaces/ISite";

const SiteContent: ISite = {
    homePage: {
        banner: {
            title: "Triple A",
            slogan: "- A bot to remember",
            intro: "Level up your voice chat experience with Triple A, your all-around audio assistant!  Need to adjust the volume, skip a song, or even play some background tunes? No problem!  Triple A is here to help you take control and make your voice channel hangouts smoother than ever. So, crank up the mic and let's get chatting!",
            icon: Icons.Discord
        },
        featureList: {
            title: "Features",
            features: []
        }
    },
    termsOfUsePage: {},
    errorPage: {
        banner: {
            title: "",
            link: {}
        }
    }
};

export default SiteContent;