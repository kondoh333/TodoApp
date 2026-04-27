# TodoApp

本アプリは「設計を意識したアプリ開発」を目的として作成しました。
C#(Windows Forms)で作成したタスク管理アプリです。
タスクの追加・削除・完了管理が可能です。

## 機能

- タスクの追加
- タスクの削除
- タスクの完了切替
- アプリ終了時に自動保存
- 保存形式の切り替え (txt / JSON)

## 使用技術

- C#
- .NET (Windows Forms)
- ファイル保存(txt / JSON)
- System.Text.Json

## アーキテクチャ

本アプリは責務分離を意識したレイヤー構造で設計しています。

Form : UI (画面操作のみ担当)  
↓  
ITaskService  
↓
TaskService : 業務ロジック (タスク管理・入力チェック)
↓  
ITaskRepository : 保存処理の抽象  
↓  
FileTaskRepository　/　JsonTaskRepository : 保存処理の実装

各層が独立することで、変更の影響範囲を限定できる構造としています。
依存性注入(DI)により、保存方法の差し替えを可能にしています。

## タスク追加の流れ

1. ユーザーがテキスト入力
2. ボタン押下 (またはEnterキー)
3. Form1がTaskServiceを呼び出す
4. TaskServiceで入力チェック
    - 空文字の場合は例外を発生
5. TaskItemを生成
6. BindingListに追加
7. ListBoxに自動反映

## 保存の流れ

1. ユーザーがアプリを閉じる
2. Form1がTaskService.Save()を呼び出す
3. TaskServiceが現在のタスクリストを取得
4. Programで注入されたRepositoryが保存を担当する
5. 選択された保存方法 (txt / JSON) でタスクが保存される

## 工夫した点

本アプリでは、拡張性と保守性を意識した設計を行いました。

- UI(Form)と業務ロジック(Service)を分離し、責務を明確化
- Repositoryパターンを用いて保存処理を抽象化
- ITaskRepositoryを導入し、保存方法の差し替えを可能にした
- Program.csで依存性注入（DI）を行い、txtとJSONの切り替えを実現
- BindingListとINotifyPropertyChangedによりUIの自動更新を実現
- 入力チェックをService層に配置し、UIとの責務分離を実現
- 例外をServiceからUIへ伝播させ、ユーザーへ適切に通知
- 入力エラー時は例外を発生させ、UI層でキャッチしてユーザーに通知する設計とした

## 今後の改善

- MVVMへのリファクタリング
- データバインディングの強化
- 単体テストの導入