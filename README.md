# Vector 演習５

## 動作チェック

1. `Assets/kadai3/Scenes/kadai5.unity` シーンを開く
1. 実行する
    - 左右カーソルキーで移動
    - 左右カーソルキーの同時押しで弾発射
    - R キーでリセット
1. 実行を停止する
1. `Flyer` GameObject の `FlyerControllerRel` の各種スピードを変更して実行し、操縦しにくいことを確認する。
    - `pitchSpeed` : 上下方向の回転トルク
    - `yawSpeed` : 左右方向の回転トルク
1. `Flyer` GameObject の `FlyerControllerRel` の `isRecoveryMode` のチェックを入れて実行する。
    - `recoverySpeed` の値を 0.2 くらいまで上げて、動作を観察する。

## プログラムの解説

### [FlyerControllerRel.cs](Assets/kadai3/Scripts/FlyerControllerRel.cs)

上下左右のカーソルキーに対応して、飛行体にトルクを与える。

```csharp
Rigidbody rb = GetComponent<Rigidbody>();
if( Input.GetKey(KeyCode.LeftArrow) )
{
    rb.AddTorque( -transform.up * yawSpeed );
}
if( Input.GetKey(KeyCode.RightArrow) )
{
    rb.AddTorque( transform.up * yawSpeed );
}
if( Input.GetKey(KeyCode.UpArrow) )
{
    rb.AddTorque( transform.right * pitchSpeed );
}
if( Input.GetKey(KeyCode.DownArrow) )
{
    rb.AddTorque( -transform.right * pitchSpeed );
}
```

リカバリーモードの場合は x 軸の回転を打ち消す。

```csharp
if( isRecoveryMode )
{
    Vector3 av = rb.angularVelocity;
    Vector3 localav =
transform.InverseTransformDirection(GetComponent<Rigidbody>().angularVelocity);
    rb.AddTorque( -transform.right * localav.x * recoverySpeed );
}
```

## プログラム読解

### 問題１

[FlyerControllerRel.cs](Assets/kadai3/Scripts/FlyerControllerRel.cs) 内で、
リカバリーモードのときには「ローカルな x 軸周りの回転が徐々にゆっくりになる」処理が記述されている。
どのように実現されているか、簡単に解説しなさい。

#### 回答記入欄



## プログラム記述

修正は、最終的に `kadai5` ブランチにコミットする形で提出すること。

### 問題１

[FlyerControllerRel.cs](Assets/kadai3/Scripts/FlyerControllerRel.cs) 内で、
リカバリーモードのときに、ローカルな x,y,z の軸のそれぞれの回転が緩やかになるようプログラムを記述しなさい。（すでに x 軸は記述済み）
