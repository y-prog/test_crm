import { test, expect } from '@playwright/test';

test('New customer can register and log in', async ({ page }) => {
  // Step 1: Navigate to the registration page
  await page.goto('http://localhost:5173/register');

  // Step 2: Fill in the registration form with unique credentials
  await page.fill('input[name="email"]', 'newuser3@example.com');
  await page.fill('input[name="password"]', 'securePassword123');
  await page.fill('input[name="username"]', 'newuser3');
  await page.fill('input[name="company"]', 'NewUserCorp3');
  await page.click('button[type="submit"]');

  // Step 3: Wait for navigation to the homepage after successful registration
  await page.waitForNavigation({ waitUntil: 'domcontentloaded' });

  // Step 4: Assert that the current URL is the homepage
  await expect(page).toHaveURL('http://localhost:5173/login');

  // Step 5: Log in with the newly registered credentials
  await page.goto('http://localhost:5173/login');
  await page.fill('input[name="email"]', 'newuser3@example.com');
  await page.fill('input[name="password"]', 'securePassword123');
  await page.click('button[type="submit"]');

  // Step 6: Wait for navigation to the homepage after login
  await page.waitForNavigation({ waitUntil: 'domcontentloaded' });

  // Step 7: Assert that the current URL is the homepage
  await expect(page).toHaveURL('http://localhost:5173');
});
