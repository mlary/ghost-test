export const getLinkedInProfileFromUrl = (url: string) => {
  let normalizedUrl = url;
  if(!url.includes("https://")){
    normalizedUrl = `https://${url}`;
  }
  console.log(normalizedUrl);
  const urlObj = new URL(normalizedUrl);
  const segments = urlObj.pathname.split('/');
  const profileId = segments[2];
  const normalizedProfileId = profileId.split("?");
  return normalizedProfileId[0];
};
