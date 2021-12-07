# Vector 演習３

## 動作チェック

1. `Assets/kadai3/Scenes/kadai3.unity` シーンを開く
2. 実行する
  - 左右カーソルキーで移動
  - 左右カーソルキーの同時押しで弾発射
  - R キーでリセット
3. 実行を停止する

## プログラムの解説

### [GameLoop.cs](Assets/kadai3/Scripts/GameLoop.cs)

R キーが押されたら、全体をリセットする。

```csharp
void Update()
{
    if( Input.GetKey(KeyCode.R) )
        SceneManager.LoadScene(0);
}
```

### [BulletController.cs](Assets/kadai3/Scripts/BulletController.cs)

弾が何かに当たったら、それを消滅させる。

```csharp
void OnCollisionEnter(Collision c)
{
    Debug.Log("Hit!");
    if( c.gameObject.CompareTag("Enemy") )
    {
        c.gameObject.SetActive(false);
    }
}
```

### [ShootingController.cs](Assets/kadai3/Scripts/ShootingController.cs)

クールダウン中でないときに、両カーソルキーが同時に押されたら

```csharp
if( !isCoolingDown )
{
    if( Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow) )
    {
```

弾を移動方向前方に出現させ、

```csharp
        Vector3 d = GetComponent<Rigidbody>().velocity;
        d.Normalize();
        Vector3 p = transform.position + d * 1.5f;
        GameObject tama = Instantiate(tamaPrefab, p , Quaternion.identity);
```

移動方向に向けて初速度を与え、

```csharp
        Vector3 v = gameObject.GetComponent<Rigidbody>().velocity;
        tama.GetComponent<Rigidbody>().velocity = v * 3;
```

２秒間のクールダウンタイムに入る。

```csharp
        StartCoroutine( StartCoolDown() );
```


### [FlyerControllerAbs.cs](Assets/kadai3/Scripts/FlyerControllerAbs.cs)

左右のカーソルキーに対応して、飛行体を左右に動かす。

```csharp
void Update()
{
    if( Input.GetKey(KeyCode.LeftArrow) )
    {
        GetComponent<Rigidbody>().AddForce( Vector3.left );
    }
    if( Input.GetKey(KeyCode.RightArrow) )
    {
        GetComponent<Rigidbody>().AddForce( Vector3.right );
    }
}
```

## プログラム読解

### 問題１

[FlyerControllerAbs.cs](Assets/kadai3/Scripts/FlyerControllerAbs.cs) 内で、
「左右に動かす」処理がどのように実現されているか、簡単に説明しなさい。

#### 回答記入欄



### 問題２

[ShootingController.cs](Assets/kadai3/Scripts/ShootingController.cs) 内で、
「弾の出現位置」が、飛行体の移動速度によらず機体の前方一定距離に置かれるようになっている。どのように実現されているか、簡単に説明しなさい。

#### 回答記入欄



## プログラムの修正

修正は、最終的に master にコミットする形で提出すること。

### 問題１

[FlyerControllerAbs.cs](Assets/kadai3/Scripts/FlyerControllerAbs.cs) 内で、
上下カーソルで、世界のｚ軸方向 (`Vector3.forward`, `Vector3.back`) に移動するようにプログラムを書き換え、提出しなさい。

### 予習問題

[FlyerControllerAbs.cs](Assets/kadai3/Scripts/FlyerControllerAbs.cs) を [FlyerControllerRel.cs](Assets/kadai3/Scripts/FlyerControllerRel.cs) に
置き換え、動作を観察しなさい。
