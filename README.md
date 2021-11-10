# プロジェクトの準備

## リーダー: テンプレート リポジトリを Fork する

各チームのリーダーは、ゲームジャム課題となるプロジェクトの[テンプレート リポジトリ](https://github.com/LeonAkasaka/GameJam)を Fork してください。

![image](https://user-images.githubusercontent.com/441716/141150134-0ff3e7ba-9906-49b6-a933-23abd81bcdf1.png)

## リーダー: チームメンバーを招待する

次に、フォークしたリポジトリ（`https://github.com/自分のアカウント/GameJam`） の設定からチームメンバーをコラボレーターとして招待します。リポジトリのメニューから「Settings」を選択し、画面左の「Manage access」項目を選択してください。認証が求められた場合は指示に従って入力します。

![image](https://user-images.githubusercontent.com/441716/141151254-c1be97dd-2765-47b0-a039-7fa49d67b9ca.png)

「Add people」ボタンを押して、自分のリポジトリに招待したいユーザーを探します。

![image](https://user-images.githubusercontent.com/441716/141153288-6e3a9376-f935-4c61-b144-7a8c3778d46c.png)

## メンバー: リポジトリへの招待を受ける（）

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

