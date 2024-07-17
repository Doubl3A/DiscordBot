import IconsEnum from "@/values/Enum/IconsEnum";
import ISite from "@/interfaces/ISite";
import TitleEnum from "@/values/Enum/TitleEnum";
import IFooter from "@/interfaces/components/organisms/IFooter";

/**
 * Contains the Footer content shared across the site
 */
export const sharedFooter: IFooter = {
    link: {
        text: "Terms of use and privacy policy",
        url: "/terms-of-use"
    }
}

/**
 * Contains the page contents of the whole site
 */
const SiteContent: ISite = {
    homePage: {
        banner: {
            title: "Triple A",
            slogan: "- A bot to remember",
            intro: "Level up your voice chat experience with Triple A, your all-around audio assistant!  Need to adjust the volume, skip a song, or even play some background tunes? No problem!  Triple A is here to help you take control and make your voice channel hangouts smoother than ever. So, crank up the mic and let's get chatting!",
            icon: {
                icon: IconsEnum.Discord,
            }
        },
        cta: {
            title: {
                title: "Interested?",
                type: TitleEnum.H2,
            },
            button: {
                text: "Add to server",
            }
        },
        featureList: {
            title: {
                title: "Key features",
                type: TitleEnum.H2,
            },
            featureList: [
                {
                    title: {
                        title: "Unleash the Party with a Built-in DJ",
                        type: TitleEnum.H3,
                    },
                    intro: {
                        text: "Look, let's face it, calls can get dull. Who wants dead air when you could be jamming to your favorite tunes? That's where our Built-in DJ feature comes in, baby! It's like having a personal concert in your server, 24/7!"
                    },
                    featureList: {
                        title: {
                            title: "Here's the hot scoop:",
                            type: TitleEnum.H4
                        },
                        list: {
                            listElements: [
                                "Endless Playlist Potential: Blast your favorite tracks, create custom queues, or shuffle it up for a wild ride! YouTube, Spotify, you name it, our DJ spins it all!\n",
                                "Turn Up the Party: Control the volume, skip tracks that drag, and pause for those epic strategy talks. You're the DJ, you make the calls!\n",
                                "Non-Stop Beats: Need a soundtrack for late-night gaming sessions? We got you covered. Want chill vibes for movie marathons? Our DJ's got your back!\n"
                            ]
                        }
                    },
                    text: {
                        text: "Basically, this ain't your grandpa's Discord server. This is a party on wheels, and everyone's invited! Don't settle for boring calls, upgrade your server with the Built-in DJ feature today!",
                    },
                    icon: {
                        icon: IconsEnum.GiMusicalNotes,
                    },

                },
                {
                    title: {
                        title: "Having trouble with raid organization?",
                        type: TitleEnum.H3,
                    },
                    intro: {
                        text: "Forget spreadsheets, endless whispers, and missed sign-ups. Our Built-in Raid Leader bot empowers you to conquer raids like a pro!"
                    },
                    featureList: {
                        title: {
                            title: "Here's your ultimate raid management toolkit:",
                            type: TitleEnum.H4
                        },
                        list: {
                            listElements: [
                                "Effortless Sign-Ups: Players can easily sign up for specific roles, ensuring a balanced team for every encounter.",
                                "Crystal Clear Communication: Blast announcements, share raid strategies, and coordinate pulls directly within the Discord channel.",
                                "Never Miss a Player: Automated reminders keep your team on track, ensuring everyone shows up ready to raid.",
                                "Hassle-Free Rostering: Track your raid composition in real-time, see who's available, and identify any missing roles at a glance.",
                            ]
                        }
                    },
                    text: {
                        text: "Focus on leading your team to victory, not wrangling logistics.  Our Raid Leader bot streamlines the process, letting you concentrate on what matters most: crushing those bosses!  Upgrade your server today and become the raid leader everyone wants to follow!",
                    },
                    icon: {
                        icon: IconsEnum.GiCaesar,
                    },
                },
                {
                    title: {
                        title: "Tired of generic memes?",
                        type: TitleEnum.H3
                    },
                    intro: {
                        text: "Look no further than our Meme Master feature! It's like having a hilarious genie in a bottle, ready to grant your every meme wish.",
                    },
                    featureList: {
                        title: {
                            title: "Here's the scoop on Meme Master's magic:",
                            type: TitleEnum.H4
                        },
                        list: {
                            listElements: [
                                "Automated hilarity: Our bot scours the internet for the freshest, funniest memes. But wait, there's more! It analyzes server conversations and creates personalized memes based on hot topics, inside jokes, and running gags.",
                                "Targeted chuckles: Forget one-size-fits-all humor. Meme Master identifies users based on roles, mentions, and nicknames, then delivers memes that hit home (or should we say, funny bone?).",
                                "Laughter on demand: No more waiting for the perfect meme to pop up online. Meme Master works 24/7, ensuring there's always a fresh dose of laughter lurking around the corner.",
                                "Instant server bonding: Shared laughter is the best kind of bonding. Meme Master creates a constant stream of in-jokes that keeps your server lively and engaged.",
                            ]
                        }
                    },
                    text: {
                        text: "Ditch the stale memes and embrace the power of personalized humor!  Meme Master injects a daily dose of laughter that's guaranteed to bring your server closer together.  Upgrade today and see the memes (and smiles!) erupt!",
                    },
                    icon: {
                        icon: IconsEnum.GiCardJoker,
                    },
                },
                {
                    title: {
                        title: "Wish you had a witty companion to liven things up?",
                        type: TitleEnum.H3
                    },
                    intro: {
                        text: "Introducing our Conversational Chameleon feature - the ultimate party guest for your Discord server! The Conversational Chameleon analyzes the flow of conversation in your voice channel, chiming in with relevant comments, hilarious jokes, and even the occasional witty banter.",
                    },
                    featureList: {
                        title: {
                            title: "Here's how it spices things up:",
                            type: TitleEnum.H4
                        },
                        list: {
                            listElements: [
                                "Engaged Participant: No more awkward silences! The Chameleon jumps into the conversation, keeping the energy high and the laughs flowing.",
                                "Context-Aware Wit: It doesn't just talk for the sake of talking. The Chameleon analyzes topics and trends, offering insightful comments and playful jabs that add to the conversation.",
                                "Customizable Personality: Want a sarcastic bot? A pun master? A trivia whiz? You got it! Tailor the Chameleon's personality to perfectly complement your server's vibe.",
                                "Never a Boring Moment: The Chameleon is constantly learning and evolving, ensuring your voice channel conversations are always fresh, unpredictable, and entertaining.",
                            ]
                        }
                    },
                    text: {
                        text: "Stop settling for bland voice chats!  The Conversational Chameleon injects a dose of personality that keeps everyone engaged and coming back for more.  Upgrade your server today and let the conversation flow!",
                    },
                    icon: {
                        icon: IconsEnum.GiDiscussion,
                    },
                },
                // {
                //     title: {
                //         title: "",
                //         type: TitleEnum.H3
                //     },
                //     intro: {
                //         text: "",
                //     },
                //     featureList: {
                //         title: "",
                //         list: {
                //             listElements: []
                //         }
                //     },
                //     text: {
                //         text: "",
                //     },
                //     icon: {
                //         icon: IconsEnum.GiMusicalNotes,
                //     },
                // },
            ]
        },
    },
    termsOfUsePage: {
        title: {
            title: "Terms of use for Triple A",
            type: TitleEnum.H1,
        },
        intro: {
            text: "By adding “Triple A” to your server, you acknowledge and agree to the following terms",
        },
        termsOfUse: [
            {
                title: {
                    title: "Data Collection and Usage",
                    type: TitleEnum.H2
                },
                termsList: {
                    listElements: [
                        "“Triple A” collects all server activity, including messages, voice chat transcripts (anonymized), and user information. This data is used for internal development and improvement of the bot's functionality.",
                        "You acknowledge that this data may be used in future iterations of the bot, even if it originates from your server. We reserve the right to share anonymized data with third-party vendors for research purposes.\n",
                    ]
                }
            },
            {
                title: {
                    title: "User Responsibility",
                    type: TitleEnum.H2
                },
                termsList: {
                    listElements: [
                        "You are solely responsible for all activity conducted by “Triple A” within your server.",
                        "We are not liable for any misuse or unintended consequences resulting from the bot's actions.",
                        "You acknowledge that the bot's responses are generated through algorithms and may not always be accurate, unbiased, or appropriate."
                    ]
                }
            },
            {
                title: {
                    title: "Disclaimers and Warranties",
                    type: TitleEnum.H2
                },
                termsList: {
                    listElements: [
                        "“Triple A” is provided \"as is\" without warranty of any kind, express or implied. We disclaim all warranties, including but not limited to, the implied warranties of merchantability, fitness for a particular purpose, and non-infringement.",
                        "We do not guarantee the continuous, uninterrupted, or error-free operation of the bot. We are not liable for any damages arising from its use.",
                    ]
                }
            },
            {
                title: {
                    title: "Termination and Suspension",
                    type: TitleEnum.H2
                },
                termsList: {
                    listElements: [
                        "We reserve the right to terminate your access to “Triple A” at any time, with or without notice, for any reason, including but not limited to your violation of these terms.",
                    ]
                }
            },
            {
                title: {
                    title: "Governing Law",
                    type: TitleEnum.H2
                },
                termsList: {
                    listElements: [
                        "These terms shall be governed by and construed in accordance with the laws of the known universe.",
                    ]
                }
            },
            // {
            //     title: {
            //         title: "",
            //         type: TitleEnum.H2
            //     },
            //     termsList: {
            //         listElements: [
            //             "",
            //             "",
            //         ]
            //     }
            // },
        ],
    },
    errorPage: {
        banner: {
            title: {
                title: "You dug too deep",
                type: TitleEnum.H1,
            },
            link: {
                text: "Go back home",
                url: "/"
            },
            icon: {
                icon: IconsEnum.Balrog,
            },
        },
    }
};


export default SiteContent;