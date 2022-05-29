using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupTalkManager : MonoBehaviour
{
    
    Dictionary<int,string[]> groupTalk;
    Dictionary<int, string[]> talkName;
    Dictionary<int,Sprite> traitData;
    string[] ezzz={"우리는 운동을 하면서 친목을 다지는 동아리야.:0","혹시 관심 있니?:2"};
    string[] firstTalk={"와 동아리 종류가 많은 걸? 무슨 동아리가 있는지 둘러보자!:1"};
    string[] endTalk={"어떤 동아리에 가입할거니?:0"};
    string[] selectBand={"악기를 연주하며 스트레스도 풀고 재밌겠는걸? 나도 가입해봐야 겠다.:2"};
    string[] selectPerform={"내가 만든 노래로 공연도 해보고 보람차고 재밌을거 같아!:0","나도 가입해야 겠다.:2"};
    string[] selectEnglish={"사회나 내 전공과 관련된 동아리라 도움이 많을거 같아:0","나도 가입해야 겠다.:2"};
    string[] selectVoluteer={"봉사활동을 하면 굉장히 보람찰거 같아.:0","나도 가입해야 겠다.:2"};
    string[] selectSports={"내가 좋아하는 운동을 하면서 건강과 재미를 챙기니 재밌을거야.:0","나도 가입해야 겠다.:2"};
    string[] selectHobby={"내가 좋아하는 것을 다른 사람들이랑 교류하면서 노는것은 재밌을 거 같아:0","나도 내 취미와 맞는 동아리를 찾아 봐야지:2"};
    string[] selectReligion={"신앙생활을 하면서 대학생활도 같이 해야지!:0","함께 친목도 다지면서 재밌을거야!:2"};
    string[] aboutHealth={"우리는 운동을 하면서 친목을 다지는 동아리야.:0","혹시 관심 있니?:2"};
    string[] aboutBand={"혹시 노래부르는거나 기타나 드럼, 베이스 치는거에 관심 있니?:0","같이 악기도 배우고 공연도 해보면서 재밌게 놀지 않을래? 재밌을거야.:2"};
    string[] aboutPerform={"공연분야 동아리들이 많은데 혹시 관심 있니?:0","무슨 동아리가 있는지 알려줄게!:2"};
    string[] aboutVolunteer={"봉사활동을 하면서 뿌듯함을 느껴보지 않을래?.:2"};
    string[] aboutEnglish={"사회나 학술 관련 동아리에 대해 알아볼래?:0"};
    string[] aboutReligion={"혹시 종교에 관심이 있니?:0"};
    string[] aboutHobby={"만화나 여행등 취미활동에 관심이 있니?:0"};
    string[] aboutClimbing={"사랑, 도전, 극복!:2","산악부는 실내 또는 실외에서 클라이밍을 하거나 자연 암벽을 즐기는 동아리야:0","클라이밍에 관심 있으면 산악부에 가입해볼래?:2"};
    string[] aboutFakie={"FAKIE는 경험과 추억을 쌓는 가천대학교 익스트림 레저 스포츠 동아리야:0","번지점프, 수상레저, 패러글라이딩 등의 다양한 활동을 하고 있어:2","다양한 레저스포츠를 경험 하고 싶거나 관심이 있다면 FAKIE에 대해 생각해봐!:2"};
    string[] aboutgachonhealth={"가천헬스회는 헬스에 관심이 있는 사람들이 함께 운동하며 건강한 몸을 만들고 친목을 도모하는 동아리야:0","헬스에 대해 많이 공유하고 함께 운동하는거에 관심이 있으면 가입해볼래?:2"};
    string[] abouttiebreak={"타이브레이크는 테니스 동아리야!:0","테니스를 즐겨치는 사람들 뿐만이 아니라 모르는 사람들 까지도 함께 배우며 즐겨 칠 수 있어!:2","매주 훈련을 할 뿐만 아니라 타 대학교와 교류전도 하니 관심이 있으면 가입해봐!:0"};
    string[] aboutstingray={"스팅레이는 스킨 스쿠버를 하는 동아리야!:0","강사 자격증을 보유한 선배들이 직접 스킨스쿠버다이빙 교육을 진행하고 있어:0","기초 등급의 자격증 부터 강사 교육까지 교육할 수 있고 자격증을 취득한 이후 계절마다 다이빙을 진행해!:0","스팅레이에 가입해보지 않을래?:2"};
    string[] aboutAtlas={"ATLAS는 농구를 좋아하고 열정을 가진 사람들의 모임이야!:0","매주 1회 가천대학교 체육관에서 정기훈련을 해:0","자유투, 레이업 뿐만이 아니라 전술 훈련까지 하고 있어!:0","타 학교와의 교류전을 하기도 하고 각종 대회에 참여를 하고 있어:2","ATLAS에 가입해보는게 어때?:2"};
    string[] aboutSword={"검도부는 검도를 하며 친해지는 동아리야:2","정기운동을 하여 상대방을 존중하는 생각을 가지며 유대감을 형성하거나 타격과 대련을 통해 스트레스를 해소 할 수있지!:0","경기도 대학 연맹전이라는 대회참가를 통해 다양한 사람들과 대련을 하여 경험을 쌓을 수 있어!:0","검도부에서 검도 배워보지 않을래?:0"};
    string[] aboutCross={"크로스핏GCU는 크로스핏을 하며 땀을 빼는 동아리야!:0","매주 일요일마다 크로스핏 운동관에서 전문 코치님께 강습을 받으며 운동을 해.:2","운동은 매번 다른 방식으로 진행이 되며 한 사람이 여러 사람을 가르치는 형식으로 진행해:0","크로스핏GCU에 가입해보지 않을래?:0"};
    string[] aboutWind={"가천WIND는 가천대학교에서 전문적으로 야구를 즐길 수 있는 동아리야.:0","매주 금요일, 토요일마다 학교운동장에서 정기연습을 진행하고 있어!:2","또한 여러 전국대회를 통해서 타대학과 교류해 경기를 진행하기도 해!:2","야구에 관심이 많으면 가천WIND는 어때?:0"};
    string[] aboutConnect={"CONNECT는 배드민턴 동아리야!:0","일주일에 1회 추가적으로 1~2회정도 상시운동을 진행하고 있어 실력향상과 다양한 학과 친구들과 소통할 수 있지!:0","한국 대학 배드민턴 동아리 연합회에 가입되어 있어서 40여개의 타 대학교와 교류하여 교류전도 진행하지.:2","배드민턴에 관심이 있으면 CONNECT에 가입해보지 않을래?:2"};
    string[] aboutGeneral={"천하대장군은 다양한 장르를 연주하고 놀며 락을 사랑하는 사람들이 모인 동아리야!:0","곡 회의를 통해서 곡을 선정하고 정기적으로 모여서 합주를 진행해!:2","봄, 가을에는 정기공연이 있고 방학 때는 외부공연도 하고 있어:2","천하대장군에서 같이 연주해보지 않을래?:0"};
    string[] aboutMusicwind={"하늬바람은 편안한 분위기에서 열정적으로 음악을 즐기는 밴드 동아리야!:0","축제와 정기공연에 참가할 뿐 아니라 악기 연주하는법을 잘 가르쳐 주고 있어:2","하늬바람에서 악기도 같이 배우고 공연 해보면서 재밌는 학교생활을 보내볼래?:2"};
    string[] aboutSound={"현음은 다양한 음악을 연주하며 추억을 쌓는 밴드 동아리야.:0","5월, 11월에 방학 혹은 학기 중에 합주해 왔던 곡으로 정기 공연을 진행하고 있어!:2","짝을 이룬 선후배가 하루 동안 자유롭게 놀며 유대감을 쌓는 선후배 짝 데이트와 같은 행사도 있으니 재밌을거야!:2","현음에 가입해서 유대감을 형성해보자!:2"};
    string[] aboutGoodSound={"고운소리는 어쿠스틱 밴드 동아리야:0","매 학기마다 정기공연을 하고 있어:0","악기 교실이란 행사를 통해서 자신의 분야 외의 다른 악기를 배워 볼 수 있고 이를 통해 실력을 향상 시킬 수 있지!:2","고운 소리에서 공연하면서 재밌게 놀아보자!:2"};
    string[] aboutBird={"파랑새는 자유롭고 즐거운 밴드 동아리야!:0","매년 직접 기획한 무대에서 정기공연을 하여 지인 혹은 가족에게 멋진 모습을 보여줄 수도 있지!:2","악기를 잘 못다루어도 선배들이 친절하게 잘 알려 줄거야.:0","파랑새에서 즐겁게 밴드활동 해보지 않을래?:2"};
    string[] aboutMakeCulture={"문예창작단은 다양한 친목도모를 추구하는 밴드 동아리야!:0","일주일마다 정기적으로 모든 파트가 파트별로 스터디를 진행해 실력을 키우고 있어:0","학기당 한번의 정기공연과 외부공연을 진행하고 있어!:2","문예창작단에 가입해서 재밌게 놀자!:0"};
    string[] aboutChorong={"음초롱은 클래식&통기타 동아리야.:0","레슨, 개인 또는 단체 버스킹, 음초롱 연주회 등 기타를 통한 다양한 활동을 진행해.:0","뿐만 아니라 초롱디오, 마니또 활동과 같은 재밌는 활동이 많으니 음초롱에서 통기타 한번 배워보자!:2"};
    string[] aboutEpu={"E.PU는 춤을 사랑하는 사람들이 모인 스트릿 댄스 동아리야:0","연 2회의 정기공연과 교내외 프로젝트를 통해 다양한 공연을 할 수 있어:0","또한 다양한 스트릿 장르의 춤을 접해볼 수 있지.:0","춤에 관심이 많으면 E.PU에서 스트릿댄스를 배워보자!:2"};
    string[] aboutSoundbox={"소리상자는 자신의 곡을 만들어 공연하는 공연 동아리야.:0","랩과 보컬, 미디 와 믹싱을 통해서 곡을 만들고 있어!:0","부원들이 협심하여 만든 곡이나 개인별로 만든 곡 또는 커버곡을 이용하여 학기 말에 정기공연을 진행해:0","소리상자에서 노래를 만들어 볼까?:2"};
    string[] aboutFivefinger={"다섯손가락은 수화 스터디와 수화 노래공연을 하는 가천대 유일 수화동아리야!:0","수어퀴즈와 수어스터디를 진행해 부원들끼리 기본적인 수어 단어를 배우고 익힐 수 있어:2","해마다 주제를 선정하여 노래연습을 하고 지인을 초청해 작은 공연을 진행해:2","다섯손가락에서 같이 수어를 배워보자!:0"};
    string[] aboutAreum={"아름은 무려 40년이라는 전통을 가진 가천대학교 유일무이한 연극동아리야!:0","워크숍과 여름방학 또는 겨울방학에 정기공연을 진행하고 있어:0","뿐만 아니라 다같이 연극을 보고 연극에 대해 생각해보는 시간도 가질 수 있어:2","아름에서 같이 연극해보자!:2"};
    string[] aboutAla={"A.L.A는 선배, 동기들과 함께 영어와 가까워지는 영어동아리야!:0","A.L.A 에서는 일주일에 한번 함께 영어수업을 진행하고 있어.:0","2학기에는 토익을 공부하고 LC대회와 같은 각종 콘테스트를 진행하고 있지:0","뿐만 아니라 마니또, 멘토-멘티와 같은 다양한 친목활동도 하고 있으니 함께 영어를 배우고 싶다면 A.L.A 에 가입해보자!:2"};
    string[] aboutEnjoy={"엔조이리스크는 주식에 대해서 알 수 있는 동아리야!:0","모의투자대회를 통해서 주식투자의 실전감각을 기를 수 있고 기업분석을 하여 투자 능력을 기를 수 있지.:0","또한 자연스러운 토론을 통해서 경제관련 다양한 정보를 접할 수 있고 친목활동을 통해서 다양한 학우들을 알아갈 수 있어!:0","엔조이리스크에서 주식투자에 대해서 배워보자!:2"};
    string[] aboutApplay={"@pplay는 코딩과 친목 동아리야!:0","컴퓨터와 코딩과 관련된 많은 정보를 얻을 수 있지.:0","또한 앱잼이라는 동아리 내 공모전을 통해서 동기들과 함께 작품을 완성시켜 능력을 발전 시킬 수 있어:0","배우고 싶은 언어가 있다면 함께 공부하여 언어를 배울수도 있지:2","@pplay에서 코딩에 대해서 배우고 다양한 친구들을 만나보자!:2"};
    string[] aboutInactor={"인액터스는 비즈니스로 사회 문제를 해결하는 글로벌 연합 동아리야:0","인액터스에서는 전체회의와 팀회의 2번의 회의를 진행하고 프로젝트에 대해 정기적으로 논의하고 피드백을 받는 시간을 가지고 있어:0","또한 구상했던 프로젝트를 직접 실천하여 대상자분들을 직접 만나거나 기업과 협업 경험을 쌓을 수 있지.:0","인액터스에서 사업모델을 구상해보고 커뮤니케이션을 해보는 경험을 해보자!:2"};
    string[] aboutTakeout={"Take Out은 임베디드 시스템 개발 동아리야.:0","기본적인 집적회로의 동작 원리와 주변 기능 들에 대해 이해할 수 있고 간단한 하드웨어 설계를 통해 원하는 작품을 직접 만들어 볼 수 있어:0","스터디를 진행하고 다양한 공모전에 참가하여 실적을 쌓을 수도 있다구!:2","Take Out에서 임베디드 시스템에 대해서 배워보자!:2"};
    string[] aboutUbf={"U.B.F 는 1대1 성경공부를 통해서 예수님을 알아가는 기독교 동아리야.:0","간사님과 1대1로 성경공부를 진행하고 일주일에 한번 정기 모임을 가지고 있어.:0","또한 야외모임을 가지고 수련회를 진행하기도 하지:2","U.B.F 에서 성경공부를 해보지 않을래?:2"};
    string[] aboutCam={"C.A.M 은 함께 모여 예배드리는 기독교 동아리야.:0","동아리방에서 함께 찬양과 예배를 드리고 간사와 학생 1대 1양육을 통해서 신앙을 키울 수 있어:0","또한 여름수련회와 겨울수련회를 통해서 부원들과 함께 예배하며 정기적인 활동과 모임을 진행해:2","C.A.M 에서 같이 예배드리자!:2"};
    string[] aboutCcc={"C.C.C 는 함께 기도하는 기독교 동아리야.:0","순모임으로 선배들과 1대1로 매칭되어 개인만남을 이어가 좋은 관계를 만들어 갈 수 있지:0","매주 목요일 채플을 하여 찬양과 예배를 드리는 시간을 가지고 있어:0","또한 여름방학 때는 수련회를 진행하여 다양한 행사를 진행하고 있지:2","C.C.C 에서 같이 신앙생활을 해볼래?:2"};
    string[] aboutCatholic={"가톨릭 학생회는 신자나 가톨릭에 관심있는 사람들의 의견을 나누는 동아리야.:0","매주 수요일마다 주모임을 진행하고 있고 매 학기 한번 열린 미사를 진행하고 있지:0","또한 한달에 한번 동아리방에서 정기미사와 성당 평일 미사 참례등의 활동을 진행해:2","가톨릭에 관심있으면 가톨릭 학생회에 가입해보는거 어때?:2"};
    string[] aboutSnapshot={"스냅샷은 다양한 출사를 통해 추억을 쌓아가는 사진동아리야:0","정기적인 출사를 통해서 경복궁이나 놀이공원과 같은 다양한 곳에서 사진을 찍으며 부원들과 추억을 나눌 수 있어:0","또한 찍었던 사진들로 전시회를 개최하여 투표를 통해 상품도 준다고!:2","스냅샷에서 부원들과 사진을 찍으며 추억을 쌓아보자!:2"};
    string[] aboutDoodle={"낙서둥지는 취미로 그림을 그리고 서브컬처를 좋아하는 사람들의 모임이야:0","매 학기 동아리 회원들이 원하는 그림을 교내에 전시하고 동아리 회원들끼리 서로 도와주며 교류가 활발히 이루어지지:0","또한 전시회 관람이나 소규모 모임 등 회원 간의 교류가 많이 이루어지고 있지:2","낙서둥지에서 같이 그림 그려보자!:2"};
    string[] aboutHostel={"유스호스텔은 여행을 다니면서 추억을 쌓는 여행동아리야:0","봄과 가을을 맞이하여 동아리원들과 호스텔링을 통하여 다양한 여행지를 방문하고 추억을 쌓고 있어:0","또한 매년 동아리 창립을 기념하여 각자의 재능을 뽐내는 단합회도 진행하고 있지:2","유스호스텔에서 같이 다양한 장소를 여행해 보자!:2"};
    string[] aboutKusa={"KUSA는 다양한 봉사활동을 하는 연합 봉사동아리야:0","나눔쿠키 제작, 국제어린이 마라톤 스태프 활동, 마스크 제작등 다양한 봉사들을 정기적으로 진행하고 있어:0","다양한 학과의 학우들을 만날 수 있고 타 대학교와 연합활동을 하고 있지:2","동아리 회원들을 위한 간식행사도 있는데 KUSA는 어때?:2"};
    string[] aboutStar={"별지기는 벽화봉사를 메인으로 하는 봉사활동, 취미미술 동아리야:0","보육원, 노인복지회관, 초등학교등에서 벽화로 재능기부를 하고 있어:0","또한 드로잉, 그립톡 만들기 등의 미술활동과 전시회 탐방등의 재밌는 미술활동도 하고 있지:2","그림으로 봉사활동을 하고 미술활동도 같이 할 수 있는 별지기는 어때?:2"};
    string[] aboutHo={"호우회는 누구나 부담없이 참여할 수 있는 봉사 친목 동아리야.:0","무료 급식 봉사, 사회적인 행사의 진행 보조, 나무 심기등 다양한 종류의 봉사를 정기적으로 진행하고 있어:0","또한 다양한 친목활동도 있어 다양한 사람들과 교류할 수 있지:2","교내 봉사활동 시간도 채울 수 있는데 호우회에서 같이 봉사활동 할래?:2"};
    public bool EndStory=false;
    public bool PopUp=false;
    public GroupManager groupmanager;
    public GameObject selectPanel;
    public GameObject Panel;
    public GameObject musicSelect;
    public GameObject performSelect;
    public GameObject societySelect;
    public GameObject religionSelect;
    public GameObject hobbySelect;
    public GameObject sport1Select;
    public GameObject sport2Select;
    public GameObject frAnim;
    private Animator friendAnimation;
    public Sprite[] imgarr;
    // Start is called before the first frame update
    void Awake()
    {
        groupTalk=new Dictionary<int, string[]>();
        traitData=new Dictionary<int,Sprite>();
        talkName = new Dictionary<int, string[]>();
        friendAnimation=frAnim.GetComponent<Animator>();
        DataSet();

        
    }
    void DataSet()
    {
       
        groupTalk.Add(2000,firstTalk);
        groupTalk.Add(3000,aboutHealth);
        groupTalk.Add(4000,aboutEnglish);
        groupTalk.Add(5000,aboutBand);
        groupTalk.Add(6000,aboutVolunteer);
        groupTalk.Add(7000,aboutHealth);
        groupTalk.Add(8000,aboutReligion);
        groupTalk.Add(9000,aboutHobby);
        groupTalk.Add(10+2000,firstTalk);
        groupTalk.Add(11+2000,firstTalk);
        groupTalk.Add(11+3000,aboutHealth);
        groupTalk.Add(11+4000,aboutEnglish);
        groupTalk.Add(11+5000,aboutBand);
        groupTalk.Add(11+6000,aboutVolunteer);
        groupTalk.Add(11+7000,aboutHealth);
        groupTalk.Add(11+8000,aboutReligion);
        groupTalk.Add(11+9000,aboutHobby);

        talkName.Add(2000,new string[]{"친구"});
        talkName.Add(3000,new string[]{"선배"});
        talkName.Add(4000,new string[]{"선배"});
        talkName.Add(5000,new string[]{"선배"});
        talkName.Add(6000,new string[]{"선배"});
        talkName.Add(7000,new string[]{"선배"});
        talkName.Add(8000,new string[]{"선배"});
        talkName.Add(9000,new string[]{"선배"});

        traitData.Add(1000+0,imgarr[0]);
        traitData.Add(1000+1,imgarr[1]);
        traitData.Add(1000+2,imgarr[2]);
        traitData.Add(1000+3,imgarr[3]);
        traitData.Add(2000+0,imgarr[0]);
        traitData.Add(2000+1,imgarr[1]);
        traitData.Add(2000+2,imgarr[2]);
        traitData.Add(2000+3,imgarr[3]);
        traitData.Add(3000+0,imgarr[4]);
        traitData.Add(3000+1,imgarr[5]);
        traitData.Add(3000+2,imgarr[6]);
        traitData.Add(3000+3,imgarr[7]);
        traitData.Add(4000+0,imgarr[0]);
        traitData.Add(4000+1,imgarr[1]);
        traitData.Add(4000+2,imgarr[2]);
        traitData.Add(4000+3,imgarr[3]);
        traitData.Add(5000+0,imgarr[4]);
        traitData.Add(5000+1,imgarr[5]);
        traitData.Add(5000+2,imgarr[6]);
        traitData.Add(5000+3,imgarr[7]);
        traitData.Add(6000+0,imgarr[0]);
        traitData.Add(6000+1,imgarr[1]);
        traitData.Add(6000+2,imgarr[2]);
        traitData.Add(6000+3,imgarr[3]);
        traitData.Add(7000+0,imgarr[4]);
        traitData.Add(7000+1,imgarr[5]);
        traitData.Add(7000+2,imgarr[6]);
        traitData.Add(7000+3,imgarr[7]);
        traitData.Add(8000+0,imgarr[0]);
        traitData.Add(8000+1,imgarr[1]);
        traitData.Add(8000+2,imgarr[2]);
        traitData.Add(8000+3,imgarr[3]);
        traitData.Add(9000+0,imgarr[4]);
        traitData.Add(9000+1,imgarr[5]);
        traitData.Add(9000+2,imgarr[6]);
        traitData.Add(9000+3,imgarr[7]);

    }
    public string getName(int id, int nameIndex)
    {
        return talkName[id][nameIndex];
    }
    public void SelectClub(string i)
    {
        switch(i)
        {
            case "1":
                EndStory=true;
                GameData.gamedata.groupname="Music";
                selectPanel.SetActive(false);
                groupTalk[2011]=selectBand;
                groupmanager.GroupTalking(2000,true);
                Panel.SetActive(true);
                break;
            case "2":
                EndStory=true;
                GameData.gamedata.groupname="Religion";
                selectPanel.SetActive(false);
                groupTalk[2011]=selectReligion;
                groupmanager.GroupTalking(2000,true);
                Panel.SetActive(true);
                break;
            case "3":
                EndStory=true;
                GameData.gamedata.groupname="Major";
                selectPanel.SetActive(false);
                groupTalk[2011]=selectEnglish;
                groupmanager.GroupTalking(2000,true);
                Panel.SetActive(true);
                break;
            case "4":
                EndStory=true;
                GameData.gamedata.groupname="Health";
                selectPanel.SetActive(false);
                groupTalk[2011]=selectSports;
                groupmanager.GroupTalking(2000,true);
                Panel.SetActive(true);
                break;
            case "5":
                EndStory=true;
                GameData.gamedata.groupname="Performance";
                selectPanel.SetActive(false);
                groupTalk[2011]=selectPerform;
                groupmanager.GroupTalking(2000,true);
                Panel.SetActive(true);
                break;
            case "6":
                EndStory=true;
                GameData.gamedata.groupname="Hobby";
                selectPanel.SetActive(false);
                groupTalk[2011]=selectHobby;
                groupmanager.GroupTalking(2000,true);
                Panel.SetActive(true);
                break;
            case "stopsport1":
                sport1Select.SetActive(false);
                groupTalk[3011]=aboutHealth;
                break;
            case "stopsport2":
                sport2Select.SetActive(false);
                groupTalk[7011]=aboutHealth;
                break;
            case "stopmusic":
                musicSelect.SetActive(false);
                groupTalk[5011]=aboutBand;
                break;
            case "stopperform":
                performSelect.SetActive(false);
                groupTalk[6011]=aboutPerform;
                break;
            case "stopsociety":
                societySelect.SetActive(false);
                groupTalk[4011]=aboutEnglish;
                break;
            case "stopreligion":
                religionSelect.SetActive(false);
                groupTalk[8011]=aboutReligion;
                break;
            case "stophobby":
                hobbySelect.SetActive(false);
                groupTalk[9011]=aboutHobby;
                break;
            case "climb":
                sport1Select.SetActive(false);
                groupTalk[3011]=aboutClimbing;
                groupmanager.GroupTalking(3000,true);
                Panel.SetActive(true);
                break;
            case "fakie":
                sport1Select.SetActive(false);
                groupTalk[3011]=aboutFakie;
                groupmanager.GroupTalking(3000,true);
                Panel.SetActive(true);
                break;
            case "gachonhealth":
                sport1Select.SetActive(false);
                groupTalk[3011]=aboutgachonhealth;
                groupmanager.GroupTalking(3000,true);
                Panel.SetActive(true);
                break;
            case "tiebreak":
                sport1Select.SetActive(false);
                groupTalk[3011]=abouttiebreak;
                groupmanager.GroupTalking(3000,true);
                Panel.SetActive(true);
                break;
            case "stingray":
                sport1Select.SetActive(false);
                groupTalk[3011]=aboutstingray;
                groupmanager.GroupTalking(3000,true);
                Panel.SetActive(true);
                break;
            case "ala":
                societySelect.SetActive(false);
                groupTalk[4011]=aboutAla;
                groupmanager.GroupTalking(4000,true);
                Panel.SetActive(true);
                break;
            case "enjoy":
                societySelect.SetActive(false);
                groupTalk[4011]=aboutEnjoy;
                groupmanager.GroupTalking(4000,true);
                Panel.SetActive(true);
                break;
            case "applay":
                societySelect.SetActive(false);
                groupTalk[4011]=aboutApplay;
                groupmanager.GroupTalking(4000,true);
                Panel.SetActive(true);
                break;
            case "inactor":
                societySelect.SetActive(false);
                groupTalk[4011]=aboutInactor;
                groupmanager.GroupTalking(4000,true);
                Panel.SetActive(true);
                break;
            case "takeout":
                societySelect.SetActive(false);
                groupTalk[4011]=aboutTakeout;
                groupmanager.GroupTalking(4000,true);
                Panel.SetActive(true);
                break;
            case "musicwind":
                musicSelect.SetActive(false);
                groupTalk[5011]=aboutMusicwind;
                groupmanager.GroupTalking(5000,true);
                Panel.SetActive(true);
                break;
             case "bird":
                musicSelect.SetActive(false);
                groupTalk[5011]=aboutBird;
                groupmanager.GroupTalking(5000,true);
                Panel.SetActive(true);
                break;
             case "sound":
                musicSelect.SetActive(false);
                groupTalk[5011]=aboutSound;
                groupmanager.GroupTalking(5000,true);
                Panel.SetActive(true);
                break;
             case "goodsound":
                musicSelect.SetActive(false);
                groupTalk[5011]=aboutGoodSound;
                groupmanager.GroupTalking(5000,true);
                Panel.SetActive(true);
                break;
             case "makeculture":
                musicSelect.SetActive(false);
                groupTalk[5011]=aboutMakeCulture;
                groupmanager.GroupTalking(5000,true);
                Panel.SetActive(true);
                break;
             case "general":
                musicSelect.SetActive(false);
                groupTalk[5011]=aboutGeneral;
                groupmanager.GroupTalking(5000,true);
                Panel.SetActive(true);
                break;
             case "chorong":
                performSelect.SetActive(false);
                groupTalk[6011]=aboutChorong;
                groupmanager.GroupTalking(6000,true);
                Panel.SetActive(true);
                break;
             case "epu":
                performSelect.SetActive(false);
                groupTalk[6011]=aboutEpu;
                groupmanager.GroupTalking(6000,true);
                Panel.SetActive(true);
                break;
             case "soundbox":
                performSelect.SetActive(false);
                groupTalk[6011]=aboutSoundbox;
                groupmanager.GroupTalking(6000,true);
                Panel.SetActive(true);
                break;
             case "fivefinger":
                performSelect.SetActive(false);
                groupTalk[6011]=aboutFivefinger;
                groupmanager.GroupTalking(6000,true);
                Panel.SetActive(true);
                break;
             case "areum":
                performSelect.SetActive(false);
                groupTalk[6011]=aboutAreum;
                groupmanager.GroupTalking(6000,true);
                Panel.SetActive(true);
                break;
             case "atlas":
                sport2Select.SetActive(false);
                groupTalk[7011]=aboutAtlas;
                groupmanager.GroupTalking(7000,true);
                Panel.SetActive(true);
                break;
             case "connect":
                sport2Select.SetActive(false);
                groupTalk[7011]=aboutConnect;
                groupmanager.GroupTalking(7000,true);
                Panel.SetActive(true);
                break;
             case "sword":
                sport2Select.SetActive(false);
                groupTalk[7011]=aboutSword;
                groupmanager.GroupTalking(7000,true);
                Panel.SetActive(true);
                break;
             case "crossfit":
                sport2Select.SetActive(false);
                groupTalk[7011]=aboutCross;
                groupmanager.GroupTalking(7000,true);
                Panel.SetActive(true);
                break;
             case "gachonwind":
                sport2Select.SetActive(false);
                groupTalk[7011]=aboutWind;
                groupmanager.GroupTalking(7000,true);
                Panel.SetActive(true);
                break;
             case "ubf":
                religionSelect.SetActive(false);
                groupTalk[8011]=aboutUbf;
                groupmanager.GroupTalking(8000,true);
                Panel.SetActive(true);
                break;
             case "cam":
                religionSelect.SetActive(false);
                groupTalk[8011]=aboutCam;
                groupmanager.GroupTalking(8000,true);
                Panel.SetActive(true);
                break;
             case "ccc":
                religionSelect.SetActive(false);
                groupTalk[8011]=aboutCcc;
                groupmanager.GroupTalking(8000,true);
                Panel.SetActive(true);
                break;
             case "catholic":
                religionSelect.SetActive(false);
                groupTalk[8011]=aboutCatholic;
                groupmanager.GroupTalking(8000,true);
                Panel.SetActive(true);
                break;
             case "snapshot":
                hobbySelect.SetActive(false);
                groupTalk[9011]=aboutSnapshot;
                groupmanager.GroupTalking(9000,true);
                Panel.SetActive(true);
                break;
             case "doodle":
                hobbySelect.SetActive(false);
                groupTalk[9011]=aboutDoodle;
                groupmanager.GroupTalking(9000,true);
                Panel.SetActive(true);
                break;
             case "hostel":
                hobbySelect.SetActive(false);
                groupTalk[9011]=aboutHostel;
                groupmanager.GroupTalking(9000,true);
                Panel.SetActive(true);
                break;
             case "kusa":
                hobbySelect.SetActive(false);
                groupTalk[9011]=aboutKusa;
                groupmanager.GroupTalking(9000,true);
                Panel.SetActive(true);
                break;
             case "star":
                hobbySelect.SetActive(false);
                groupTalk[9011]=aboutStar;
                groupmanager.GroupTalking(9000,true);
                Panel.SetActive(true);
                break;
             case "ho":
                hobbySelect.SetActive(false);
                groupTalk[9011]=aboutHo;
                groupmanager.GroupTalking(9000,true);
                Panel.SetActive(true);
                break;
            
        }
    }
    public string GetTalk(int id,int talkIndex)
    {
        if(id==2010)
        {
            
            if(groupTalk[id]==endTalk)
            {
                if(talkIndex==groupTalk[id].Length)
                {
                    if(!EndStory)
                    {
                        selectPanel.SetActive(true);
                    }
                    return null;
                }
                    else
                        return groupTalk[id][talkIndex];
            }
            else
            {
                if(talkIndex==groupTalk[id].Length)
                    {
                        friendAnimation.SetBool("start",true);
                        return null;
                    }
                else
                    return groupTalk[id][talkIndex];
            }
        }
        if(!groupTalk.ContainsKey(id))
        {
            
            if(!groupTalk.ContainsKey(id-id%10))
            {
                if(talkIndex==groupTalk[id-id%100].Length)
                {
                    return null;
                }
                
                else
                    return groupTalk[id-id%100][talkIndex];
            }
            else{
                if(talkIndex==groupTalk[id-id%10].Length)
                {
                    
                   
                    if(groupTalk[3010]==aboutHealth)
                        sport1Select.SetActive(true);
                    else if(groupTalk[3010]==aboutClimbing||groupTalk[3010]==aboutFakie||groupTalk[3010]==aboutgachonhealth||groupTalk[3010]==abouttiebreak||groupTalk[3010]==aboutstingray)
                        {
                            sport1Select.SetActive(true);
                        }
                    return null;
                }
                else
                    return groupTalk[id-id%10][talkIndex];
            }
        }
        if(talkIndex==groupTalk[id].Length)
        {
            if(groupTalk[id]==endTalk)
            {
                selectPanel.SetActive(true);
            }
             if(EndStory){
                        //Set_Activity_sk
                        GameObject.Find("Canvas").GetComponent<FadeINOUT>().LoadFadeOut("MTStart");
                    }
             if(id-id%10==3010)
            {
                sport1Select.SetActive(true);
                groupTalk[2011]=endTalk;
            }
            if(id-id%10==4010)
            {
                societySelect.SetActive(true);
                groupTalk[2011]=endTalk;
            }
              if(id-id%10==5010)
            {
                musicSelect.SetActive(true);
                groupTalk[2011]=endTalk;
            }
              if(id-id%10==6010)
            {
                performSelect.SetActive(true);
                groupTalk[2011]=endTalk;
            }
              if(id-id%10==7010)
            {
                sport2Select.SetActive(true);
                groupTalk[2011]=endTalk;
            }
              if(id-id%10==8010)
            {
                religionSelect.SetActive(true);
                groupTalk[2011]=endTalk;
            }
              if(id-id%10==9010)
            {
                hobbySelect.SetActive(true);
                groupTalk[2011]=endTalk;
            }
            return null;
        }
        else
            return groupTalk[id][talkIndex];
        
    }
    public Sprite GetPort(int id,int imgIndex)
    {
        return traitData[id+imgIndex];
    }
}
