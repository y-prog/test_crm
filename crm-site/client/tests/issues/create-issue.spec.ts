import { test, expect } from '@playwright/test';

test('Customer can create an issue', async ({ page }) => {
  console.log("Starting the test...");

  // Go to the company issue form page
  await page.goto('http://localhost:5173/Demo%20AB/issueform');
  await page.waitForLoadState('load'); // Wait for the page to fully load
  console.log("Issue form page loaded");

  // Wait for and fill the email field
  await page.waitForSelector('input[name="email"]');
  await page.fill('input[name="email"]', 'ydg886@gmail.com');
  console.log("Email filled");

  // Wait for and fill the title field
  await page.waitForSelector('input[name="title"]');
  await page.fill('input[name="title"]', 'Issue with product');
  console.log("Title filled");

  // Use getByLabel to target the subject dropdown and select an option
  await page.getByLabel('Subject').selectOption('Reklamation'); // Select the option by value
  console.log("Subject selected");

  // Wait for and fill the message field
  await page.waitForSelector('textarea[name="message"]');
  await page.fill('textarea[name="message"]', 'The product broke after 2 weeks of use.');
  console.log("Message filled");

  // Submit the form (click on the "Create Issue" button)
  await page.click('button[type="submit"]'); 
  console.log("Issue created");

});
