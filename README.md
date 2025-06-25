# README - GithubActionBuildTests (CI/CD Focus)

# 🔄 CI/CD Pipeline Overview

Проект реализует полный CI/CD цикл с использованием:
- **GitHub Actions** для сборки и тестирования
- **Docker** для контейнеризации
- **Google Cloud Build** для деплоя в Cloud Run
- **Автоматического тестирования** при каждом коммите

# 🌐 CI/CD Workflows

## 1. GitHub Actions Pipeline (CI)
Файл: `.github/workflows/myTestPipeline.yml`

**Триггеры:**
- При пуше в ветку `master`
- При пулл-реквесте в ветку `master`

**Этапы:**
```yaml
jobs:
  build:
    runs-on: ubuntu-latest
    steps:
    - checkout@v3
    - setup-dotnet@v3 (установка .NET 6)
    - dotnet build (сборка решения)
    - dotnet test (запуск всех тестов)
```

**Особенности**

Автоматический запуск тестов
Проверка сборки на разных ОС
Кэширование зависимостей
## 2. Production Deployment (CD)
Файл: **`cloudbuild.yaml`**
Этапы деплоя:

1. Сборка Docker-образа
```yaml
- name: 'gcr.io/cloud-builders/docker'
  args: ['build', '-t', '$_SERVICE_IMAGE', '.', '-f', 'Dockerfile']
```

2. Пуш в Artifact Registry
```yaml
- name: 'gcr.io/cloud-builders/docker'
  args: ['push', '$_SERVICE_IMAGE']
```

3. Деплой в Cloud Run
```yaml
- name: 'gcr.io/cloud-builders/gcloud'
  args: ['run', 'services', 'update', ..., '--image=$_SERVICE_IMAGE']
```
Переменные окружения:

```yaml
_SERVICE_IMAGE: northamerica-northeast1-docker.pkg.dev/${PROJECT_ID}/...
_SERVICE_REGION: northamerica-northeast1
_SERVICE_PROJECT: intershipdeployprod
```
# 🛠️ Локальная разработка с CI/CD
## Docker Compose Setup
```bash
docker-compose up -d  # Запуск приложения + PostgreSQL
```
**Сервисы:**
- `githubactionbuildtests`: .NET приложение (порт 7021)
- `gabt_db`: PostgreSQL (порт 5433)

**Тестирование изменений**
1. Изменения кода → коммит в feature-ветку
2. Создание Pull Request → автоматический запуск тестов
3. После мержа в master → автоматический деплой в прод

# 🔍 Мониторинг пайплайна
1. **GitHub Actions:**
   - Вкладка "Actions" в репозитории
   - Детализация по каждому запуску
2. **Google Cloud Build:**
   - Логи в Cloud Console
   - История деплоев

# 🚀 Ручной деплой
Для экстренного деплоя:
```bash
gcloud builds submit --config=cloudbuild.yaml
```
