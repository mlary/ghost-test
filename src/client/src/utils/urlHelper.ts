export const getLinkedInProfileFromUrl = (url: string) => {
  const urlObj = new URL(url);
  const segments = urlObj.pathname.split('/');
  const profileId = segments[segments.length - 2];
  const normalizedProfileId = profileId.split("?");
  return normalizedProfileId[0];
};
