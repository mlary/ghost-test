import * as yup from 'yup';
import { AnswerTypes, PositionSeniorityLevels } from '~/app/ApiClient';
import { VALIDATION_MESSAGES } from '~/const/validationMessages';

export type RateFormData = {
  commonRating?: number;
  interviewRound?: number;
  positionSeniorityLevel?: PositionSeniorityLevels;
  lateInMinutes?: number;
  cancelledInterview?: boolean;
  interviewerListeningRate?: number;
  interviewerInterestRate?: number;
  comment?: string;
  visitedLinkedInProfile?: AnswerTypes;
  questionsRate?: number;
};

export const initialRateFormData: RateFormData = {
  comment: '',
  visitedLinkedInProfile: AnswerTypes.Unknown,
};
export const rateFormSchema = yup.object().shape({
  commonRating: yup.number().required(VALIDATION_MESSAGES.enterRequiredField),
  interviewRound: yup.number().required(VALIDATION_MESSAGES.enterRequiredField),
  positionSeniorityLevel: yup.string().required(VALIDATION_MESSAGES.enterRequiredField),
  lateInMinutes: yup.number(),
  cancelledInterview: yup.boolean().required(VALIDATION_MESSAGES.enterRequiredField),
  interviewerListeningRate: yup.number().required(VALIDATION_MESSAGES.enterRequiredField),
  interviewerInterestRate: yup.number().required(VALIDATION_MESSAGES.enterRequiredField),
  comment: yup.string(),
  questionsRate: yup.number().required(VALIDATION_MESSAGES.enterRequiredField),
  visitedLinkedInProfile: yup.string(),
});
