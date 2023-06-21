import * as yup from 'yup';
import { URL_EXPRESSION } from '~/const/regexExpressions';
import { VALIDATION_MESSAGES } from '~/const/validationMessages';

export type RecruiterLinkFormData = {
  linkedInUrl: string;
  companyName: string | undefined;
  companyId?: number;
};
const EXAMPLE_LINK = "Example: https://www.linkedin.com/in/brucewayne23/";
export const initialRecruiterLinkData: RecruiterLinkFormData = {
  linkedInUrl: '',
  companyName: '',
};

export const recruiterLinkSchema = yup.object().shape({
  linkedInUrl: yup
    .string()
    .required(`${VALIDATION_MESSAGES.enterRequiredField}. ${EXAMPLE_LINK}`)
    .test(
      'linkedinMatch',
      VALIDATION_MESSAGES.enterValidUrl,
      (value) => value?.includes('linkedin.com/in/') ?? false,
    )
    .matches(URL_EXPRESSION, `${VALIDATION_MESSAGES.enterValidUrl}. ${EXAMPLE_LINK}`),
  companyName: yup.string().nullable().notRequired(),
});
