using System.Diagnostics;

namespace SmartWalk
{
    public partial class MainPage : ContentPage
    {
        //現在の位置情報を取得する
        private CancellationTokenSource _cancelTokenSource;
        private bool _isCheckingLocation;

        public async Task GetCurrentLocation()
        {
            try
            {
                _isCheckingLocation = true;

                GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

                _cancelTokenSource = new CancellationTokenSource();

                Location location2 = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);

                if (location2 != null)
                    Console.WriteLine($"Latitude: {location2.Latitude}, Longitude: {location2.Longitude}, Altitude: {location2.Altitude}");
            }
            // Catch one of the following exceptions:
            //   FeatureNotSupportedException
            //   FeatureNotEnabledException
            //   PermissionException
            catch (Exception ex)
            {
                // Unable to get location
            }
            finally
            {
                _isCheckingLocation = false;
            }
        }

        //最新の位置情報を取得する
        public void CancelRequest()
        {
            if (_isCheckingLocation && _cancelTokenSource != null && _cancelTokenSource.IsCancellationRequested == false)
                _cancelTokenSource.Cancel();
        }

        public async Task<string> GetCachedLocation()
        {
            try
            {
                Location location1 = await Geolocation.Default.GetLastKnownLocationAsync();

                if (location1 != null)
                    return $"Latitude: {location1.Latitude}, Longitude: {location1.Longitude}, Altitude: {location1.Altitude}";
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }

            return "None";
        }


        //豆知識の箱
        String[] mame5 = new string[] {


        "S-1.缶詰のオイルやサラダ油で簡易的なランプをつくることができる",
        "S-2.硬い肉はコーラなどの炭酸飲料で柔らかくなる",
        "S-3.掛け布団の上に毛布をかけた方が温かい。",
        "S-4.服についたカレーの染みは天日干しをするだけでキレイに落ちる。",
        "S-5.ご飯は氷・ハチミツでいつもより美味しく炊ける"
         };
        String[] mame4 = new string[] {
        "A-1.ぬるい缶ビールや缶ジュースは、ボウルなどに氷を半分ほど入れ、その上で缶をコロコロ回すと数分でキンキンに冷える。",
        "A-2.剥がしづらいシールは、ヘアスプレーをかけて少し待つと簡単にはがすことができる。",
        "A-3.車に酔いやすい場合、イヤフォンなどで音楽を聴いていると酔いづらくなる。",
        "A-4.切れた電池は擦れば復活する",
        "A-5こびりついた油汚れはレモンで楽に落とせる"
        };
        String[] mame3 = new string[] {
        "B-1電話で「#7119」にかけると、救急車を呼ぶかどうか迷った時に対応してくれる所にかかる。",
        "B-2エアコンの室外機を日光に当たらないようにするだけで電気代を節約することができる。",
        "B-3.歯を磨くとき、歯ブラシは濡らさない方がより綺麗に磨ける",
        "B-4.ジャイアンの名言「おまえの物はおれの物、おれの物もおれの物」はイギリスのことわざ。",
        "B-5.カメハメハ大王のカメハメハは「孤独な人」という意味" };
        String[] mame2 = new string[]{
        "C-1.「のりたま」にはこしあんが入っている。",
        "C-2.現在の日本では、馬で公道を走ることができる。",
        "C-3.紙幣と硬貨は発行元が違う。",
        "C-4.サイコロは６面それぞれの穴の数によって重量に誤差が出る為、出る目の確率は均等ではない。※一番出やすい目の数は５だと言われている。",
        "C-5.スイカは腐ると爆発する。"
        };
        String[] mame1 = new string[]{
        "D-1.人の首を切り落とし、頭をボールの代わりに蹴って遊んでいたのがサッカーの始まり。",
        "D-2.思うつぼ」の壺は、博打でサイコロを振るときに使う壺のこと",
        "D-3.スマホにおしりふきのカバーを張り付けると小銭入れになる",
        "D-4.排水溝の汚れを取りたいときは、酸性の汚れを取る重曹で擦る次にアルカリ性の汚れを取るクエン酸を混ぜ合わせることで二酸化炭素が発生する。",
        "D-5.右足をだし左足をだすを繰り返すと歩ける。さらに、速度をあげると走れる"
         };
        //おみくじの箱
        String[] un = new string[]
        { 
            "大吉",
            "中吉",
            "小吉",
            "吉",
            "凶",
            "大凶",
            "老害"
        };

          Location maeshutoku ;
        int count = 0;


        public MainPage()
        {
            InitializeComponent();

        }



        public void smartClicked(object sender, EventArgs e)
        {


         if (count >= 0)
            {
                

              

                String Y = "";

                tishiki.Text = Y;
            }
            else
            {
                
            }
           
        }
        public void LuckyClicked(object sender, EventArgs e)
        {
                Random o = new Random();
                int randomValue1 = o.Next(0,5);
                int j = randomValue1;

                String R = un [j];

               unsei.Text = R;
            
              
        }
       
    }
}
