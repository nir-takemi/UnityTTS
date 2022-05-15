# UnityTTS
- Unityでモバイルアプリ向けのTTS(Text To Speech)を簡易に実装するためのアセット
- 現状英語の読み上げのみ対応しています

# 対象ビルド
- iOS
- Android

# 準備
## unitypackageのDL
以下から最新のものをダウンロードしてください  
https://github.com/nir-takemi/UnityTTS/releases

# 実装
1. DLした.unitypackageをmenuからimport  
<img width="500" alt="image" src="https://user-images.githubusercontent.com/10418442/68995076-22992080-08cd-11ea-8c88-e435b6d40dd4.png">

2. Sampleは任意で、その他にチェックがされていることを確認の上import  
<img width="500" alt="image" src="https://user-images.githubusercontent.com/10418442/168462753-28f84564-b25d-4e43-b317-0e41eed5d8e5.png">

3. (Android向け)minify設定している場合、該当のネームスペースを難読化されないようにする
    1. Project Settings > Player > Android > Publishing SettingsでMinifyにチェック入れてる場合  
    ![image](https://user-images.githubusercontent.com/10418442/168463221-fa791135-60cd-47f2-965c-c2a390d26bf4.png)
    2. すぐ上のBuildの`Custome Proguard File`にチェックをして、表示された`proguard-user.txt`に以下を追記する
    ```
    -keep class com.yasuragitei.tts.** {
        *;
    }
    ```
4. コード上で以下のように処理を書く
    1. 初期化（アプリ起動後など、読み上げ直前は避ける）
    ```C#
    ylib.Services.UnityTTS.Init();
    ```
    2. 読み上げ
    ```C#
    ylib.Services.UnityTTS.Speech("I am Emily.");
    ```

# トラブルシューティング
## 初回のテキスト読み上げが正常に再生されない
- 初期化のタイミングが遅い可能性があります。初期化のタイミングを早めるなど、読み上げまでに時間を空けられるよう調整をお願いいたします。

## Android実行時に`ClassNotFoundException`が発生する
- 難読化の設定がうまくいっていない可能性があるので、実装手順を再度ご確認お願いいたします。
