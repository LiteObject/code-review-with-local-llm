# PR Code Review with AI

This repository includes a GitHub Actions workflow that automatically reviews pull requests using a local LLM (Ollama) model. The workflow is designed to provide automated, AI-powered code review feedback on every pull request targeting the `main` branch.

## How It Works

- **Trigger:** The workflow runs on every pull request to the `main` branch.
- **Diff Generation:** It generates a diff of the changes in the pull request, sanitizes it, and limits the size for efficient processing.
- **Ollama Model:** The workflow installs Ollama, pulls the specified model (default: `llama3.2:latest`), and ensures the model is ready.
- **Prompt Preparation:** A detailed prompt is constructed to instruct the AI to act as a real code reviewer, summarizing changes and providing actionable feedback.
- **AI Review:** The sanitized diff and prompt are sent to the Ollama API for review.
- **Feedback Posting:** The AI-generated review is posted as a comment on the pull request.
- **Job Summary:** A summary of the review and prompt is added to the workflow run.

## Requirements

- The workflow expects a self-hosted or compatible runner that can install and run Ollama (Linux/Ubuntu recommended).
- The Ollama model (`llama3.2:latest` by default) must be available for download.
- The workflow uses the `actions/github-script` action to post comments.

## Key Workflow Steps

1. **Checkout Repository**: Fetches the full repository history.
2. **Generate Diff**: Creates a diff between the PR branch and `main`.
3. **Sanitize Diff**: Keeps only code changes, removing metadata.
4. **Install & Prepare Ollama**: Installs Ollama and pulls the model.
5. **Wait for Model Readiness**: Ensures the model is ready to accept requests.
6. **Prepare Prompt**: Builds a prompt for the AI to act as a code reviewer.
7. **Run Code Review**: Sends the prompt and diff to Ollama for review.
8. **Post Review Comment**: Posts the AI's feedback as a PR comment.
9. **Add Job Summary**: Summarizes the run in the workflow summary.

## Customization

- **Model Selection:** Change the `MODEL_NAME` environment variable in the workflow to use a different Ollama model.
- **Prompt:** Edit the prompt in the `Prepare Prompt` step to adjust the review style or instructions.

## Limitations

- The workflow will not run for pull requests that only modify files in the `.github` directory (GitHub Actions security limitation).
- The workflow is designed for Linux runners and may require adaptation for other environments.

## Example Prompt Used

```
You are an experienced software engineer reviewing a pull request. Carefully review the following code changes for correctness, clarity, maintainability, and potential issues. Summarize what was changed, point out any problems or improvements, and provide constructive, actionable feedback as a code reviewer would in a real PR review.

<diff here>

PR Review:
```