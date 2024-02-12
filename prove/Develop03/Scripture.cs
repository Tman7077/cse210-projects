using System.Text.RegularExpressions;

public class Scripture
{
    // a dictionary which has key:value pairs of scripture reference:text.
    private Dictionary<string, string> _scriptures = new Dictionary<string, string>()
    {
        {
            "1 Nephi 3:7",
            "7 And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, "
            + "for I know that the Lord giveth no commandments unto the children of men, "
            + "save he shall prepare a way for them that they may accomplish the thing which he commandeth them."
        },
        {
            "2 Nephi 2:25",
            "25 Adam fell that men might be; and men are, that they might have joy."
        },
        {
            "2 Nephi 2:27",
            "27 Wherefore, men are free according to the flesh; and all things are given them which are expedient unto man. "
            + "And they are free to choose liberty and eternal life, through the great Mediator of all men, or to choose captivity and death, "
            + "according to the captivity and power of the devil; for he seeketh that all men might be miserable like unto himself."
        },
        {
            "2 Nephi 26:33",
            "33 For none of these iniquities come of the Lord; for he doeth that which is good among the children of men; "
            + "and he doeth nothing save it be plain unto the children of men; and he inviteth them all to come unto him and partake of his goodness; "
            + "and he denieth none that come unto him, black and white, bond and free, male and female; and he remembereth the heathen; "
            + "and all are alike unto God, both Jew and Gentile."
        },
        {
            "2 Nephi 28:30",
            "30 For behold, thus saith the Lord God: I will give unto the children of men line upon line, precept upon precept, "
            + "here a little and there a little; and blessed are those who hearken unto my precepts, and lend an ear unto my counsel, "
            + "for they shall learn wisdom; for unto him that receiveth I will give more; and from them that shall say, We have enough, "
            + "from them shall be taken away even that which they have."
        },
        {
            "2 Nephi 32:3",
            "3 Angels speak by the power of the Holy Ghost; wherefore, they speak the words of Christ. Wherefore, I said unto you, "
            + "feast upon the words of Christ; for behold, the words of Christ will tell you all things what ye should do."
        },
        {
            "2 Nephi 32:8-9",
            "8 And now, my beloved brethren, I perceive that ye ponder still in your hearts; "
            + "and it grieveth me that I must speak concerning this thing. For if ye would hearken unto the Spirit which teacheth a man to pray, "
            + "ye would know that ye must pray; for the evil spirit teacheth not a man to pray, but teacheth him that he must not pray. "
            + "9 But behold, I say unto you that ye must pray always, and not faint; "
            + "that ye must not perform any thing unto the Lord save in the first place ye shall pray unto the Father in the name of Christ, "
            + "that he will consecrate thy performance unto thee, that thy performance may be for the welfare of thy soul."
        },
        {
            "Mosiah 2:17",
            "17 And behold, I tell you these things that ye may learn wisdom; "
            + "that ye may learn that when ye are in the service of your fellow beings ye are only in the service of your God."
        },
        {
            "Mosiah 2:41",
            "41 And moreover, I would desire that ye should consider on the blessed and happy state of those that keep the commandments of God. "
            + "For behold, they are blessed in all things, both temporal and spiritual; "
            + "and if they hold out faithful to the end they are received into heaven, that thereby they may dwell with God in a state of never-ending happiness. "
            + "O remember, remember that these things are true; for the Lord God hath spoken it."
        },
        {
            "Mosiah 3:19",
            "19 For the natural man is an enemy to God, and has been from the fall of Adam, and will be, forever and ever, "
            + "unless he yields to the enticings of the Holy Spirit, and putteth off the natural man and becometh a saint through the atonement of Christ the Lord, "
            + "and becometh as a child, submissive, meek, humble, patient, full of love, willing to submit to all things which the Lord seeth fit to inflict upon him, "
            + "even as a child doth submit to his father."
        },
        {
            "Mosiah 4:9",
            "9 Believe in God; believe that he is, and that he created all things, both in heaven and in earth; believe that he has all wisdom, "
            + "and all power, both in heaven and in earth; believe that man doth not comprehend all the things which the Lord can comprehend."
        },
        {
            "Mosiah 18:8-10",
            "8 And it came to pass that he said unto them: Behold, here are the waters of Mormon (for thus were they called) and now, "
            + "as ye are desirous to come into the fold of God, and to be called his people, and are willing to bear one another's burdens, that they may be light; "
            + "9 Yea, and are willing to mourn with those that mourn; yea, and comfort those that stand in need of comfort, "
            + "and to stand as witnesses of God at all times and in all things, and in all places that ye may be in, even until death, that ye may be redeemed of God, "
            + "and be numbered with those of the first resurrection, that ye may have eternal life— 10 Now I say unto you, if this be the desire of your hearts, "
            + "what have you against being baptized in the name of the Lord, as a witness before him that ye have entered into a covenant with him, "
            + "that ye will serve him and keep his commandments, that he may pour out his Spirit more abundantly upon you?"
        },
        {
            "Alma 7:11-13",
            "11 And he shall go forth, suffering pains and afflictions and temptations of every kind; "
            + "and this that the word might be fulfilled which saith he will take upon him the pains and the sicknesses of his people. "
            + "12 And he will take upon him death, that he may loose the bands of death which bind his people; and he will take upon him their infirmities, "
            + "that his bowels may be filled with mercy, according to the flesh, that he may know according to the flesh how to succor his people according to their infirmities. "
            + "13 Now the Spirit knoweth all things; nevertheless the Son of God suffereth according to the flesh that he might take upon him the sins of his people, "
            + "that he might blot out their transgressions according to the power of his deliverance; and now behold, this is the testimony which is in me."
        },
        {
            "Alma 34:9-10",
            "9 For it is expedient that an atonement should be made; for according to the great plan of the Eternal God there must be an atonement made, "
            + "or else all mankind must unavoidably perish; yea, all are hardened; yea, all are fallen and are lost, "
            + "and must perish except it be through the atonement which it is expedient should be made. 10 For it is expedient that there should be a great and last sacrifice; "
            + "yea, not a sacrifice of man, neither of beast, neither of any manner of fowl; for it shall not be a human sacrifice; but it must be an infinite and eternal sacrifice."
        },
        {
            "Alma 39:9",
            "9 Now my son, I would that ye should repent and forsake your sins, and go no more after the lusts of your eyes, but cross yourself in all these things; "
            + "for except ye do this ye can in nowise inherit the kingdom of God. Oh, remember, and take it upon you, and cross yourself in these things."
        },
        {
            "Alma 41:10",
            "10 Do not suppose, because it has been spoken concerning restoration, that ye shall be restored from sin to happiness. "
            + "Behold, I say unto you, wickedness never was happiness."
        },
        {
            "Helaman 5:12",
            "12 And now, my sons, remember, remember that it is upon the rock of our Redeemer, who is Christ, the Son of God, that ye must build your foundation; "
            + "that when the devil shall send forth his mighty winds, yea, his shafts in the whirlwind, yea, when all his hail and his mighty storm shall beat upon you, "
            + "it shall have no power over you to drag you down to the gulf of misery and endless wo, because of the rock upon which ye are built, which is a sure foundation, "
            + "a foundation whereon if men build they cannot fall."
        },
        {
            "3 Nephi 11:10-11",
            "10 Behold, I am Jesus Christ, whom the prophets testified shall come into the world. 11 And behold, I am the light and the life of the world; "
            + "and I have drunk out of that bitter cup which the Father hath given me, and have glorified the Father in taking upon me the sins of the world, "
            + "in the which I have suffered the will of the Father in all things from the beginning."
        },
        {
            "3 Nephi 12:48",
            "48 Therefore I would that ye should be perfect even as I, or your Father who is in heaven is perfect."
        },
        {
            "3 Nephi 27:20",
            "20 Now this is the commandment: Repent, all ye ends of the earth, and come unto me and be baptized in my name, "
            + "that ye may be sanctified by the reception of the Holy Ghost, that ye may stand spotless before me at the last day."
        },
        {
            "Ether 12:6",
            "6 And now, I, Moroni, would speak somewhat concerning these things; I would show unto the world that faith is things which are hoped for and not seen; "
            + "wherefore, dispute not because ye see not, for ye receive no witness until after the trial of your faith."
        },
        {
            "Ether 12:27",
            "27 And if men come unto me I will show unto them their weakness. I give unto men weakness that they may be humble; "
            + "and my grace is sufficient for all men that humble themselves before me; for if they humble themselves before me, and have faith in me, "
            + "then will I make weak things become strong unto them."
        },
        {
            "Moroni 7:45-48",
            "45 And charity suffereth long, and is kind, and envieth not, and is not puffed up, seeketh not her own, is not easily provoked, "
            + "thinketh no evil, and rejoiceth not in iniquity but rejoiceth in the truth, beareth all things, believeth all things, hopeth all things, "
            + "endureth all things. 46 Wherefore, my beloved brethren, if ye have not charity, ye are nothing, for charity never faileth. Wherefore, "
            + "cleave unto charity, which is the greatest of all, for all things must fail— 47 But charity is the pure love of Christ, and it endureth forever; "
            + "and whoso is found possessed of it at the last day, it shall be well with him. 48 Wherefore, my beloved brethren, "
            + "pray unto the Father with all the energy of heart, that ye may be filled with this love, which he hath bestowed upon all who are true followers of his Son, "
            + "Jesus Christ; that ye may become the sons of God; that when he shall appear we shall be like him, for we shall see him as he is; that we may have this hope; "
            + "that we may be purified even as he is pure. Amen."
        },
        {
            "Moroni 10:3-5",
            "3 Behold, I would exhort you that when ye shall read these things, if it be wisdom in God that ye should read them, "
            + "that ye would remember how merciful the Lord hath been unto the children of men, "
            + "from the creation of Adam even down until the time that ye shall receive these things, "
            + "and ponder it in your hearts. 4 And when ye shall receive these things, I would exhort you that ye would ask God, "
            + "the Eternal Father, in the name of Christ, if these things are not true; and if ye shall ask with a sincere heart, "
            + "with real intent, having faith in Christ, he will manifest the truth of it unto you, by the power of the Holy Ghost. "
            + "5 And by the power of the Holy Ghost ye may know the truth of all things."
        }
    };
    private Reference _reference;
    private string _text;
    
    // instantiates a Scripture with an undefined Reference and blank sample text─ never used without later redefining it otherwise
    public Scripture()
    {
        _reference = new Reference();
        _text = "";
    }

    // instantiates a Scripture based on a given scripture reference
    public Scripture(Reference reference)
    {
        _reference = reference;

        // convert Reference to a reference as a string, then get the value (scripture text) in the _scriptures dictionary given that key
        string referenceString = reference.GetReference();
        _text = _scriptures[referenceString];
    }

    // pick a random scripture from the dictionary of scriptures and return the new Scripture object given that reference
    // this can take an input string of a reference, if that reference is a key in the _scriptures dictionary
    public Scripture Select(string scripture = "")
    {
        Reference reference = new Reference();

        // if no reference value is passed
        if (scripture == "")
        {
            // randomly select a number between 0 and the length of the _scriptures dict,
            // then instantiate a Scripture object based on the reference at that index
            Random randomGenerator = new Random();
            int index = randomGenerator.Next(0, _scriptures.Count());
            string referenceString = _scriptures.ElementAt(index).Key;
            reference = reference.Parse(referenceString);
            return new Scripture(reference);
        }
        else // if a reference is passed
        {
            // parse the given reference and instantiate a Scripture object given the reference
            reference = reference.Parse(scripture);
            return new Scripture(reference);
        }
    }

    // Display the scripture, somewhere between full clarity and completely hidden,
    // depending on how many times Obscure() has been run
    public void Display()
    {
        Console.WriteLine(_reference.GetReference());
        int[] verseInts = _reference.GetVerses(); // integer array containing the start and end verses
        Regex numbers = new Regex("[0-9]+");      // regular expression to match any set of numbers (both 1 and 21 would be matched as one entity)

        // if the reference is more than one verse
        if (_reference.IsMultipleVerses())
        {
            string[] verseStrings = numbers.Split(_text);   // string array containing verses, split at any number based on above regex
            List<string> verseList = verseStrings.ToList(); // because a string array is immutable, this converts verseStrings to a mutable list
            verseList.RemoveAt(0);                          // removes the first entry in the list, because it will always be an empty string
            int index = 0;

            // for each verse in verseList, starting from the first verse number and ending at the last
            for (int verseNum = verseInts[0]; verseNum <= verseInts[1]; verseNum++)
            {
                // add the string version of the verse number to the beginning of each verse
                verseList[index] = verseNum.ToString() + verseList[index];
                index++;
            }
            // display each verse on a separate line, each starting with the verse number
            foreach (string verse in verseList)
            {
                Console.WriteLine(verse);
            }
        }
        else // if there is only one verse
        {
            // display the verse, which already has the number at the start
            Console.WriteLine(_text);
        }
    }

    // replace up to 5 words (if available) with underscores
    public bool Obscure(int times)
    {
        string[] words = _text.Split(' ', StringSplitOptions.RemoveEmptyEntries); // string array where one entry is one word (or verse number), including punctuation
        Random randomIndex = new Random();
        int totalWords = words.Count();             // number of words
        int[] verses = _reference.GetVerses();      // integer array containing start and end verses
        int numVerses = verses[1] - verses[0] + 1;  // number of verses to obscure
        int lastFew = (totalWords - numVerses) % 5; // number of words that will be left after each full set of 5 is hidden, ignoring verses

        // if totalWords is divisible by 5 (if there are some multiple of 5 words to be hidden),
        // set lastFew to 5, because there will be 5 words to remove on the last round, not 0.
        if (lastFew == 0)
        {
            lastFew = 5;
        }
        int numToObscure = 5; // number of words to hide

        // if the number of remaining words (ignoring the entries that are verse numbers) is less than or equal to 5
        if (totalWords - numVerses - 5 * times == lastFew)
        {
            // set the number of words to hide to the number of remaining words
            numToObscure = lastFew;
        }
        // if all of the words have been hidden
        else if (totalWords - 5 * (times + 1) < 0) 
        {
            // this stops this function from being called again in Program.cs
            return false;
        }

        // obscure up to numToObscure words (usually 5 unless otherwise specified)
        for (int i = 0; i < numToObscure; i++)
        {
            int index;
            string word;
            
            // select a random word and hide it─
            // if the word is either the verse number or already hidden,
            // this will try again until it hides a new word successfully
            do
            {
                index = randomIndex.Next(0,words.Count());
                word = words[index];
            } while (new Word(word).GetHiddenState());
            
            // replace the original word with the hidden one
            words[index] = new Word(word).Hide();
        }

        string newText = "";

        // generate a string containing the entire verse(s), but using the hidden words
        foreach (string word in words)
        {
            newText += word + " ";
        }

        // set original text to new (partially hidden) text
        _text = newText;

        // tell Program.cs to continue hiding words
        return true;
    }
}