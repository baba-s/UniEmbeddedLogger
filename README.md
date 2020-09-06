# UniEmbeddedLogger

ソースコードにログ出力を簡単に埋め込める機能

## 使用例

### 通常

```cs
using UnityEngine;

public class Example : MonoBehaviour
{
    private void Start()
    {
        // 何らかの処理

        Debug.Log( "Start: 1" );

        // 何らかの処理
        
        Debug.Log( "Start: 2" );
        
        // 何らかの処理
        
        Debug.Log( "Start: 3" );
        
        // 何らかの処理
    }
}
```

### UniEmbeddedLogger

```cs
using Kogane;
using UnityEngine;

public class Example : MonoBehaviour
{
    private void Start()
    {
        var logger = EmbeddedLogger.Create( nameof( Start ) );
        
        // 何らかの処理

        logger.Log();

        // 何らかの処理

        logger.Log();
        
        // 何らかの処理

        logger.Log();
        
        // 何らかの処理
    }
}
```

![2020-09-06_210502](https://user-images.githubusercontent.com/6134875/92325325-9424a400-f084-11ea-9c5a-9e0d78267d73.png)

## 特徴

* 不具合調査などで関数にログを仕込んでどこの処理が呼び出されているか確認したい時に  
ログ出力の関数を記述する手間を少しだけ省略します  
* `DISABLE_UNI_EMBEDDED_LOGGER` シンボルを定義すると出力を無効化できます  
