# TodoApp

C#(Windows Forms)で作成したタスク管理アプリです。
タスクの追加・削除・完了管理が可能です。

## 機能

- タスクの追加
- タスクの削除
- タスクの完了切替
- アプリ終了時に自動保存
- 保存形式の切り替え (txt / Json)

## 仕様技術

- C#
- .NET (Windows Forms)
- ファイル保存(txt / JSON)
- System.Text.Json

## アーキテクチャ

本アプリは責務分離を意識したレイヤー構造で設計しています。

Form(UI)\
↓

