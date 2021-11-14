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

まず、修正作業を始める前に main ブランチ以外のプルリクエスト用作業ブランチを作ります。

```
git branch ブランチ名
```

作成したブランチに移動します。

```
git checkout ブランチ名
```

このブランチで作業し、修正をコミットしていきます。リモートリポジトリに提出できる段階になったら、このブランチをリポートリポジトリに push します。

```
git push origin ブランチ名
```

![image](https://user-images.githubusercontent.com/441716/141689417-c592f244-d566-4ad7-8252-29da273a04f0.png)

![image](https://user-images.githubusercontent.com/441716/141689601-3ec7cf6c-744a-42c5-abda-c68855aa3aaf.png)

## プルリクエストをレビューする

修正を main ブランチに受け入れるには、チームメンバーにプルリクエストの内容を確認してもらい approve してもらう必要があります。

![image](https://user-images.githubusercontent.com/441716/141690045-ab009d77-38fa-4513-afc4-21f241c810fb.png)

![image](https://user-images.githubusercontent.com/441716/141690083-1e3f3228-ae91-4af9-ba21-6eaeacdd3eb2.png)

![image](https://user-images.githubusercontent.com/441716/141690171-ebcb9e9c-695d-476c-80ee-3788de6f64a5.png)

![image](https://user-images.githubusercontent.com/441716/141690234-bbc18e43-44c1-44eb-a8cc-8b0d0c09565e.png)

![image](https://user-images.githubusercontent.com/441716/141690662-1be40e66-886e-4e48-aba6-1f14c8ae07cb.png)

