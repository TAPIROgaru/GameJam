# プロジェクトの準備

## リーダー: テンプレート リポジトリを Fork する

各チームのリーダーは、ゲームジャム課題となるプロジェクトの[テンプレート リポジトリ](https://github.com/LeonAkasaka/GameJam)を Fork してください。

![image](https://user-images.githubusercontent.com/441716/141150134-0ff3e7ba-9906-49b6-a933-23abd81bcdf1.png)

## リーダー: チームメンバーを招待する

次に、フォークしたリポジトリ（`https://github.com/自分のアカウント/GameJam`） の設定からチームメンバーをコラボレーターとして招待します。リポジトリのメニューから「Settings」を選択し、画面左の「Manage access」項目を選択してください。認証が求められた場合は指示に従って入力します。

![image](https://user-images.githubusercontent.com/441716/141151254-c1be97dd-2765-47b0-a039-7fa49d67b9ca.png)

「Add people」ボタンを押して、自分のリポジトリに招待したいユーザーを探します。

![image](https://user-images.githubusercontent.com/441716/141153288-6e3a9376-f935-4c61-b144-7a8c3778d46c.png)

## メンバー: リポジトリへの招待を受ける

チームメンバーは自分のアカウントでリーダーのリポジトリにアクセスしてください。招待が届いているはずです。

![image](https://user-images.githubusercontent.com/441716/141154520-8b5d25be-a4b5-496e-ab68-a49aeac0668a.png)

「View invitation」ボタンを押して詳細ページに移動します。

![image](https://user-images.githubusercontent.com/441716/141154287-3c7ede05-e4fe-4f7b-a6bf-ab8b9c7c849d.png)

「Accept invitation] ボタンを押して招待を受けます。これでチームリーダーのリポジトリに直接 push できる権限を得られます。

## リーダー: main ブランチを保護する

誰も知らないところで、密かにチームメンバーがリポジトリを変更しないようにブランチを保護するルールを追加できます。これは、チーム内で変更を共有し、互いに変更をレビューし合うのに有効です。

チームリーダーは、自分のリポジトリのメニューから「Settings」選択し、画面左の「Branches」項目を選択してください。「Branch protection rules」設定の「Add rule」ボタンを押して、新しくブランチ保護のルールを追加します。

![image](https://user-images.githubusercontent.com/441716/141155244-9be20124-7777-48fc-81d8-b9d23aaedccf.png)

「Branch name pattern」に保護するブランチ名を入力します。今回は main ブランチを保護するので `main` と入力してください。

次に「protect matching branches」設定の「Require a pull request before merging」項目にチェックを入れます。これで、チームメンバーは保護されたブランチにコミットを直接 push できなくなり、必ず別のブランチで pull request を出さなければなりません。

「Require approvals」は承認が必要な人数です。この設定は任意です。

![image](https://user-images.githubusercontent.com/441716/141155843-ba4e92de-a1c3-4f25-92c5-0efee264a370.png)

設定が完了したらページ下部の「Create」ボタンを押して確定します。

## 全員: リポジトリをクローンする

GitHub 上のリモートリポジトリの準備ができたら、自分のローカル PC にリポジトリをクローンします。GitHub デスクトップを起動して自分のアカウントにサインインしている状態で「File」メニューの「Clone repository...」を選択してください。

![image](https://user-images.githubusercontent.com/441716/141688622-9b641449-bb0e-49b9-b47c-ab51d812d4f8.png)

クローンするリポジトリを選択するダイアログが表示されます。招待が適切に行われていれば、この一覧に「チームリーダーのアカウント名/GameJam」というリポジトリが表示されているはずなので、これを選択して「Clone」ボタンを押してください。

![image](https://user-images.githubusercontent.com/441716/141688742-e2576ebf-26e6-463d-96d1-ec6e4c8545f3.png)

これで、ローカル PC にリポジトリが複製されました。以降、ここで自分の PC にクローンしたリポジトリをローカルリポジトリ、GitHub 上のリポジトリをリモートリポジトリと呼びます。

## プルリクエストを提出する

自分の PC 上で行った変更はローカルリポジトリにコミットして、目処が付いたところでリモートリポジトリに変更を取り入れるように要望を出します。プルリクエストはブランチ単位で行い、リモートリポジトリの指定のブランチに対して、ローカルリポジトリのブランチを差分として提出します。

まず、作業を始める前に main ブランチ以外のプルリクエスト用作業ブランチを作ります。

GitHub Desktop の「Current branch」をクリックし、ブランチ名の検索フィルターに咲く際したいブランチ名を入力します。指定のブランチが存在しないので「Create new branch」ボタンが表示されるので押してください。

![image](https://user-images.githubusercontent.com/441716/141818529-a0d47b75-71d6-4f8e-a927-e194530ad50d.png)

「Create a branch」ダイアログが表示されるので、ブランチ名を確認して「Create branch」ボタンを押します。ブランチ名は他のブランチ名と衝突しなければ任意ですが、チーム内で衝突せず分かりやすいルールを作るべきでしょう。（例えば "アカウント名/作業名" など）

![image](https://user-images.githubusercontent.com/441716/141819748-19829229-dae9-4aea-a1d5-f34042a3bd28.png)

これで新しいブランチが作成され、そのブランチに移動（チェックアウト）できました。

各人の修正作業は自分の作業ブランチで行い、修正をコミットしていきます。例えば、リポジトリ直下に「プルリクエスト.txt」というテキストファイルを作成し、適当なメッセージを書いてみましょう。ファイルを保存して GitHub Desktop に戻ると､変更差分が表示されます。

「Changes」からコミットするファイルにチェックを入れ、コミットメッセージを追加して「Commit to ブランチ名」ボタンを押してください。

![image](https://user-images.githubusercontent.com/441716/141823876-bf96b8e2-f402-4207-937d-8820f4aac072.png)

次にチームで共有しているリモートリポジトリに現在のブランチにコミットした内容を送信します。右側の「Publish branch」ボタンを押してください。git 用語ではこの操作を push と呼びますが、GitHub Desktop では Publish と呼んでいます。

![image](https://user-images.githubusercontent.com/441716/141824676-77d41fae-c14e-4aa5-88ee-dab81e8f6daf.png)

リモートリポジトリに push した後、リポジトリのトップページを見てください。画面上部に「Compare & pull request」というボタンが表示されているはずなので、それをクリックします。表示されていない場合は、正しく push できているかブランチを確認してください。

![image](https://user-images.githubusercontent.com/441716/141826686-7b001cc5-6c9d-4eee-b552-f659edc7ea6c.png)

「Open a pull request」ページに移動するので base ブランチに main、compare ブランチに送信した自分のブランチ名が選択されていることを確認してください。問題なければ、プルリクエストのタイトルと説明を入力して「Create pull request」ボタンを押します。

![image](https://user-images.githubusercontent.com/441716/141827337-e0d7469a-05f2-4b31-abf3-e8103551ef5f.png)

これで、リポジトリにプルリクエストが提出されました。リポジトリの 「Pull requests」タブを選択してください。他のチームメンバーからもプルリクエストが見えているはずです。

![image](https://user-images.githubusercontent.com/441716/141828029-cbb2baaa-391b-4e5c-8ae6-c477d4581625.png)

## プルリクエストをレビューする

修正を main ブランチに受け入れるには、提出者とは別のチームメンバーにプルリクエストの内容を確認してもらい approve してもらう必要があります。これをレビューと呼びます。レビューが通らなければ、変更を main ブランチに取り込めないように設定しています。

プルリクエストのページから「Files changed」タブを選択してください。

![image](https://user-images.githubusercontent.com/441716/141828179-0473695c-693d-4667-98ed-67dcfc21ee87.png)

もし、レビューをして問題が見つかった場合は、差分コードの修正部分をクリックしてコメントを残します。コメントは公開され、プルリクエストの提出者にはメール等で通知されます。

![image](https://user-images.githubusercontent.com/441716/141828635-11daa4ba-568c-4d8e-9c41-0d5234d9a401.png)

このとき、即コメントを反映させる場合は「Add single comment」ボタンを、複数箇所にコメントして最後にまとめて通知するなら「Start a review」ボタン（レビューコメントを追加済みなら「Add review comment」ボタン）押してください。

レビューが終了したら「Review changes」ボタン（レビュー中なら「Finish you review」ボタン）を押して、レビューを送信します。

![image](https://user-images.githubusercontent.com/441716/141829356-cbd861c7-f618-4409-9b2c-35d1c7e3f97e.png)

変更に問題がなければ「Approve」を選択します。変更に問題を見つけた場合は該当箇所にコメントして「Request changes」で修正を要求しましょう。なお、自分のプルリクエストに対して、自分で approve や request changes はできません。レビューは他のチームメンバーにお願いしましょう。

最後に「Submit review」でレビュー確定します。

![image](https://user-images.githubusercontent.com/441716/141690171-ebcb9e9c-695d-476c-80ee-3788de6f64a5.png)

レビューでチームメンバーがプルリクエストを approve することで、本体である main ブランチに変更を merge できるようになります。

![image](https://user-images.githubusercontent.com/441716/141690662-1be40e66-886e-4e48-aba6-1f14c8ae07cb.png)

チームリーダーは確認の上、レビューが通ったプルリクエストを merge してください。
