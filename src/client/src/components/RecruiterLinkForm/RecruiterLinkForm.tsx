/** @jsxImportSource @emotion/react */
import { css } from '@emotion/react';
import { Autocomplete, Button, Card, TextField } from '@mui/material';

import { FormikProvider, useFormik } from 'formik';
import { useCallback, useEffect, useState } from 'react';
import { CompanyDto } from '~/app/ApiClient';
import { useAppDispatch, useAppSelector } from '~/app/store';
import { getCompanies } from '~/slices/companies/companiesSlice';
import { getRecruiterByLinkedIn } from '~/slices/recruiter/recruiterSlice';
import LoadingState from '~/types/LoadingState';
import { RecruiterFields } from '~/types/recruiterFields';
import { getFormikFieldProps } from '~/utils/formikHelper';
import Spinner from '../Spinner/Spinner';
import { RecruiterLinkFormData, initialRecruiterLinkData, recruiterLinkSchema } from './RecruiterLinkModel';

const classes = {
  root: css({
    minWidth: 400,
    maxWidth: 800,
    width: '100%',
  }),
  card: css({
    display: 'flex',
    flexDirection: 'column',
    gap: 20,
    alignItems: 'center',
    padding: 16,
  }),
  formItem: css({ width: '100%' }),
  label: css({
    fontWeight: 600,
  }),
  actions: css({
    display: 'flex',
    justifyContent: 'flex-end',
    width: '100%',
  }),
  nextBtn: css({
    minWidth: 100,
  }),
  header: css({
    fontSize: '2rem',
  }),
};
type RecruiterLinkFormProps = {
  onComplete: (data: RecruiterFields) => void;
};
const RecruiterLinkForm = ({ onComplete }: RecruiterLinkFormProps) => {
  const dispatch = useAppDispatch();
  const { companies } = useAppSelector((state) => state.companies);
  const [selectedCompany, setSelectedCompany] = useState<CompanyDto | null>(null);
  const [companyName, setCompanyName] = useState<string>('');
  const { getRecruiterLoading, targetRecruiter } = useAppSelector((state) => state.recruiter);
  const [formData, setFormData] = useState<RecruiterLinkFormData>(initialRecruiterLinkData);
  const handleSubmit = useCallback(
    (values: RecruiterLinkFormData) => {
      dispatch(getRecruiterByLinkedIn(values.linkedInUrl));
      setFormData({ ...values, companyName, companyId: selectedCompany?.id });
    },
    [selectedCompany, companyName],
  );

  useEffect(() => {
    if (getRecruiterLoading === LoadingState.succeed) {
      onComplete({ ...formData, recruiterId: targetRecruiter?.id });
    }
  }, [getRecruiterLoading, targetRecruiter, formData]);

  useEffect(() => {
    dispatch(getCompanies());
  }, []);

  const formik = useFormik({
    initialValues: initialRecruiterLinkData,
    validationSchema: recruiterLinkSchema,
    onSubmit: handleSubmit,
  });
  console.log(companies);
  return (
    <FormikProvider value={formik}>
      <div css={classes.root}>
        <form id="linkedInForm" onSubmit={formik.submitForm} autoComplete="off">
          {getRecruiterLoading === LoadingState.pending && <Spinner size={32} />}
          <Card css={classes.card}>
            <h2 css={classes.header}>Enter recruiter</h2>
            <div css={classes.formItem}>
              <div css={classes.label}>LinkedIn Url</div>
              <TextField
                fullWidth
                required
                placeholder="Recruiter LinkedIn profile url"
                {...getFormikFieldProps(formik, 'linkedInUrl')}
              />
            </div>
            <div css={classes.formItem}>
              <div css={classes.label}>Email</div>
              <TextField
                required
                placeholder="Your email address"
                fullWidth
                {...getFormikFieldProps(formik, 'email')}
              />
            </div>
            <div css={classes.formItem}>
              <div css={classes.label}>Company</div>
              <Autocomplete
                fullWidth
                options={companies}
                placeholder="Recruiter Company"
                value={selectedCompany ?? { name: companyName, id: 0, companyNormalizedName: '', linkedInUrl: '' }}
                getOptionLabel={(item) => item.name}
                onChange={(_, value) => {
                  setSelectedCompany(value);
                }}
                renderInput={(props) => (
                  <TextField
                    {...props}
                    value={companyName}
                    placeholder="Recruiter Company"
                    fullWidth
                    onChange={(e) => {
                      setCompanyName(e.currentTarget.value);
                    }}
                  />
                )}
              />
            </div>
            <div css={classes.actions}>
              <Button onClick={formik.submitForm} color="primary" variant="contained" css={classes.nextBtn}>
                Next
              </Button>
            </div>
          </Card>
        </form>
      </div>
    </FormikProvider>
  );
};
export default RecruiterLinkForm;
