{
  "steps": [
    {
      "step": 1,
      "title": "Create a new branch",
      "description": "Before modifying any code, create a descriptive branch based on the task.",
      "command": "git checkout -b feature/task-name"
    },
    {
      "step": 2,
      "title": "Implement changes",
      "description": "Apply the requested code modifications."
    },
    {
      "step": 3,
      "title": "Commit changes",
      "description": "Commit your changes using the Conventional Commits specification.",
      "example": "git commit -m \"feat: ...\""
    },
    {
      "step": 4,
      "title": "Push to remote",
      "description": "Push the branch to the remote repository.",
      "command": "git push -u origin <branch-name>"
    }
  ]
}