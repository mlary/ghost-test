import * as yup from 'yup';
import { URL_EXPRESSION } from '~/const/regexExpressions';
import { VALIDATION_MESSAGES } from '~/const/validationMessages';

export type RecruiterLinkFormData = {
  linkedInUrl: string;
  companyName: string | undefined;
  companyId?: number;
};

export const initialRecruiterLinkData: RecruiterLinkFormData = {
  linkedInUrl: '',
  companyName: '',
};

export const recruiterLinkSchema = yup.object().shape({
  linkedInUrl: yup
    .string()
    .required(VALIDATION_MESSAGES.enterRequiredField)
    .test(
      'linkedinMatch',
      VALIDATION_MESSAGES.enterValidUrl,
      (value) => value?.includes('https://www.linkedin.com/in/') ?? false,
    )
    .matches(URL_EXPRESSION, VALIDATION_MESSAGES.enterValidUrl),
  companyName: yup.string().nullable().notRequired(),
});
