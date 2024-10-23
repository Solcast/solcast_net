# Base image with .NET SDK 8.0 (and runtime)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base

# Set the working directory inside the container
WORKDIR /workspace

# Install any additional tools if needed (optional)
RUN apt-get update && apt-get install -y \
    curl python3\
    git \
    && rm -rf /var/lib/apt/lists/*

ENV PYTHONDONTWRITEBYTECODE=1 \
    PYTHONUNBUFFERED=1

RUN curl -sSL https://install.python-poetry.org | python3 - \
    && ln -s /root/.local/bin/poetry /usr/local/bin/poetry

COPY pyproject.toml poetry.lock ./

RUN poetry config virtualenvs.create false \
    && poetry install --no-root --no-interaction --no-ansi --only=docs

# Default command
CMD [ "bash" ]
