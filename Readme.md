## Quick Start

1. Launch Aspire 
    ```shell
    cd src/OnlySpans.Aspire.AppHost/
    dotnet watch run
    ```

2. (Do once) Install deps
    ```shell
    cd src/onlyspans.polyleads.ui/
    npm i
    ```

## Urls
1. UI - http://localhost:15001
2. Aspire - http://localhost:15002
3. Banana Cake Pop - http://localhost:15001/api/graphql

## Tips

Чтобы открыть запустить в локальной сети необходимо изменить файл package.json

```shell
"dev": "next dev"
//в эту строку добавляем -H pc-ip, где pc-ip - локальный ip-адрес
"dev": "next dev -H pc-ip"
```
