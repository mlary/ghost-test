
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
const INTERGTRATION_API_ERROR_CDOE = 527;
export const INTERGTRATION_API_ERROR_NOTIFICATION = "ApiErrorNotification";
export type IntegrationApiErrorRespponse = {
  response: string;
  request: string;
  errorMessage: string;
};

export abstract class BaseClient {
   transformOptions(options: RequestInit): Promise<RequestInit> {
    const token = getCookie("token");
    if(token){
        options.headers = {...options.headers, "Authorization": `Bearer ${token}`,}
    }
    return Promise.resolve(options);
  }

  transformResult(
    _url: string,
    _response: Response,
    processor: (_response: Response) => Promise<void | any>
  ) {
    const { status } = _response;
    if (status === INTERGTRATION_API_ERROR_CDOE) {
      _response
        .clone()
        .text()
        .then((_responseText) => {
          const result = JSON.parse(
            _responseText
          ) as IntegrationApiErrorRespponse;
          document.dispatchEvent(
            new CustomEvent<IntegrationApiErrorRespponse>(
              INTERGTRATION_API_ERROR_NOTIFICATION,
              { detail: result }
            )
          );

          return _responseText;
        })
        .catch((error) => {
          console.error(error);
        });
    }

    return processor(_response);
  }
}
