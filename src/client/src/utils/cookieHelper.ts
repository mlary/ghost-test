export function deleteCookie(cookieName: string) {
  document.cookie = `${encodeURIComponent(cookieName)}=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;`;
}

export function getCookie(cookieName: string): string | null {
  const name = cookieName + '=';
  const decodedCookie = decodeURIComponent(document.cookie);
  const cookies = decodedCookie.split(';');

  for (let i = 0; i < cookies.length; i++) {
    const cookie = cookies[i].trim();
    if (cookie.indexOf(name) === 0) {
      return cookie.substring(name.length, cookie.length);
    }
  }

  return null;
}
export function setCookie(cookieName: string, cookieValue: string, expirationDays: number) {
  const expirationDate = new Date();
  expirationDate.setDate(expirationDate.getDate() + expirationDays);

  const cookie = `${encodeURIComponent(cookieName)}=${encodeURIComponent(
    cookieValue,
  )};expires=${expirationDate.toUTCString()};path=/`;

  document.cookie = cookie;
}
