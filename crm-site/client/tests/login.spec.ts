import { test, expect } from '@playwright/test';

test('User can log in', async ({ page }) => {
  // Go to the login page
  await page.goto('http://localhost:5173/login');  // adjust if necessary

  // Fill in login credentials
  await page.fill('input[name="email"]', 'm@email.com');  // replace with valid email
  await page.fill('input[name="password"]', 'abc123');   // replace with valid password

  // Click the login button
  const [response] = await Promise.all([
    page.waitForNavigation(), // Wait for the page to navigate (i.e., URL change)
    page.click('button[type="submit"]'),  // Adjust selector if needed
  ]);

  // Ensure that the URL after login is correct (home page or dashboard)
  await expect(page).toHaveURL('http://localhost:5173/');  // Update if needed

  // Wait for the "Home" text (or "Logout" as a backup) to be visible
  const homeTextLocator = page.locator('text=Home');
  const logoutTextLocator = page.locator('text=Logout');

  // Try to find "Home" or "Logout" to verify login success
  await expect(homeTextLocator).toBeVisible({ timeout: 10000 }).catch(async () => {
    await expect(logoutTextLocator).toBeVisible({ timeout: 10000 });
  });
});
