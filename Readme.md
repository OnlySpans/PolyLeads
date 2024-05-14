# OnlySpans.PolyLeads

## Installation

#### node_modules
```sh
cd ./src/OnlySpans.PolyLeads.UI/
npm i
```

## Запуск

#### Local UI + docker compose API
```sh
docker compose --profile api-only --env-file .env --env-file .env.api-only up
cd ./src/onlyspans.polyleads.ui/
npm run start
```

#### Local API + docker compose UI
```sh
docker compose --profile ui-only --env-file .env --env-file .env.ui-only up
cd ./src/OnlySpans.PolyLeads.Api/
dontet run
```

#### docker compose *
```sh
docker compose --profile "*" --env-file .env up
```
