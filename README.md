# TodoApp
C# Windows Forms製 Todo管理アプリ

基本的なCRUD機能に加え、以下を拡張実装しています。
- リアルタイム検索
- 優先度管理
- JSON保存
- 操作性向上を目的としたUI改善

個人開発ポートフォリオとして、
拡張のしやすさ、変更のしやすさを意識して設計しました。

## 機能

- タスクの追加
- タスクの削除
- タスクの完了切替
- リアルタイム検索（部分一致）
- 優先度設定（高・中・低）
- 優先度色分け表示
- アプリ終了時に自動保存
- 保存方式の切り替え (txt / JSON)

## 使用技術
- C#
- .NET (Windows Forms)
- System.Text.Json

## 設計・実装で使用した要素
- Repository Pattern
- コンストラクタによる依存性注入
- BindingList
- INotifyPropertyChanged

## 設計図・処理フロー

本アプリでは、設計を整理するためにアーキテクチャ図と処理フロー図を作成しました。

初期実装ではタスク追加・保存処理を中心に整理し、機能追加後は検索処理や優先度管理に合わせて全件データと表示用データの分離、優先度情報の保持などを反映しています。

### アーキテクチャ

本アプリは役割分担を意識した構成で設計しています。

Form1 : UI (画面操作のみ担当)  
↓  
ITaskService  
↓
TaskService : 業務ロジック (タスク管理・入力チェック)
↓  
ITaskRepository : 保存処理の抽象  
↓  
FileTaskRepository / JsonTaskRepository : 保存処理の実装

各層が独立することで、変更の影響範囲を限定できる構造としています。  
依存性注入（DI）により、保存方法の差し替えを可能にしています。  
検索機能追加時には全件データと表示用データを分離し、検索時も表示と元データの対応が崩れないよう設計に変更しました。

### タスク追加の流れ

1. ユーザーがテキスト入力
2. 任意の優先度を選択（高・中・低）
3. ボタン押下 (またはEnterキー)
4. Form1がTaskServiceを呼び出す
5. TaskServiceで入力チェック
    - 空文字の場合は例外を発生
6. TaskItemを生成
7. _allTasksに追加
8. ApplyFilterで表示用リスト更新
9. ListBox自動反映

### 保存の流れ

1. ユーザーがアプリを閉じる
2. Form1がTaskService.Save()を呼び出す
3. TaskServiceが現在のタスクリストを取得
4. Programで注入されたRepositoryが保存を担当する
5. 選択された保存方法 (txt / JSON) でタスクが保存される

### 検索処理の流れ

1. ユーザーが検索欄に文字入力
2. Form1がTaskService.Search()を呼び出す
3. 検索条件に合わせて表示用リストを作り直す
4. ListBoxに検索結果を表示

### アーキテクチャ図
<img width="1920" height="1080" alt="Image" src="https://github.com/user-attachments/assets/8a978f9f-ba64-406e-9d3c-3082aba625a7" />


### 処理フロー図
<img width="1920" height="1080" alt="Image" src="https://github.com/user-attachments/assets/cd7bf588-83dd-4d80-b9e1-e0a7638bf2e5" />
<img width="1920" height="1080" alt="Image" src="https://github.com/user-attachments/assets/4d526e21-ad20-4a97-a81d-c8460e750685" />
<img width="1920" height="1080" alt="Image" src="https://github.com/user-attachments/assets/f1b0d09a-8785-4f6a-9432-4b48f25a79f8" />

## 設計上の工夫

本アプリでは、拡張のしやすさと変更のしやすさを意識して設計しました。

- UIと業務ロジックを分離し責務を明確化
- Repository PatternとDIで保存方式差し替えを実現
- 入力検証と例外通知をService/UIで分担
- BindingListとINotifyPropertyChangedによりUIの自動更新を実現
- 検索機能では全件データと表示用データを分離し、表示と元データの対応を維持
- 入力ブレ防止のため優先度をenumで管理し、視認性向上のため色分け表示を実装

設計変更や不具合修正を通して、
機能追加時に既存設計を崩さないことを意識しました。

## 課題と対応

優先度追加時にJSONデシリアライズで保存データが復元できない問題が発生しました  

原因を切り分け、  
引数なしコンストラクタ追加で解決しました。

検索機能実装時に、表示用データと元データを同一のリストで管理していたため、検索後にデータの整合性が崩れる問題が発生しました。

この問題に対して、全件データと表示用データを分離する設計に変更しました。これにより、検索や削除を行っても元データが影響を受けず、状態を正しく管理できるようになりました。

この経験から、機能追加時にはデータの責務を明確にし、状態管理を意識した設計が重要であると学びました。

また、既存設計を崩さず機能追加することを意識して対応しました。

## 画面イメージ

### メイン画面
<img width="914" height="600" alt="Image" src="https://github.com/user-attachments/assets/36a3f271-7051-404e-8916-93515dc8ba1d" />

### 優先度色分け表示
<img width="914" height="600" alt="Image" src="https://github.com/user-attachments/assets/f6a95bb5-3cad-4085-bdfb-3031b36b4bc0" />

### 検索フィルタ表示
<img width="914" height="600" alt="Image" src="https://github.com/user-attachments/assets/feb44672-df12-4dd0-85e4-5b865ff3c698" />


## 今後の改善

### 機能面
- 優先度ソート
- 完了状態フィルタ
- 締切管理

### 技術面
- 設計改善（MVVMなど）の検討
- 単体テストの導入