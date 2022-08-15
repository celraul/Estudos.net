# https://awspolicygen.s3.amazonaws.com/policygen.html


resource "aws_iam_role_policy" "lambda_policy" {
  name = "lambda_policy"
  role = aws_iam_role.test_role_id

  policy = file("iam/lambda_role_policy.json")
}

resource "aws_iam_role" "lambda_role" {
  name = "lambda_role"

  assume_role_policy = file("iam/lambda-role.json")
}

data "archive_file" "lambda_zip" {
  type        = "zip"
  source_file = "index.js"
  output_path = "lambda_function.zip"
}

resource "aws_lambda_function" "test_lambda" {
  filename         = "lambda_function.zip"
  function_name    = "test_lambda"
  role             = aws_iam_role.lambda_role.arn
  handler          = "index.handler"
  source_code_hash = data.archive_file.lambda_zip.output_base64sha256
  runtime          = "nodejs6.10"
}
