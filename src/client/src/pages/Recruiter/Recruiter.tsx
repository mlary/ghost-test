/** @jsxImportSource @emotion/react */
import { css } from '@emotion/react';
import { useCallback, useEffect } from 'react';
import { useNavigate } from 'react-router';
import { useAppDispatch, useAppSelector } from '~/app/store';
import RecruiterLinkForm from '~/components/RecruiterLinkForm';
import RecruiterPersonForm from '~/components/RecruiterPersonForm/RecruiterPersonForm';
import { setRecruiterData } from '~/slices/rate/rateSlice';
import { resetRecruiters } from '~/slices/recruiter/recruiterSlice';
import LoadingState from '~/types/LoadingState';
import { RecruiterFields } from '~/types/recruiterFields';
const classes = {
  root: css({
    alignItems: 'center',
    display: 'flex',
    justifyContent: 'center',
    height: '100%',
  }),
};

const Recruiter = () => {
  const navigate = useNavigate();
  const { targetRecruiter, createRecruiterLoading} = useAppSelector((state) => state.recruiter);
  const dispatch = useAppDispatch();
  useEffect(() => {
    dispatch(resetRecruiters());
  }, []);
  const { recruiterData } = useAppSelector((state) => state.rate);

  

  useEffect(() => {
    if (createRecruiterLoading === LoadingState.succeed && targetRecruiter) {
      navigate('/rate');
    }
  }, [createRecruiterLoading, targetRecruiter]);

  const handleLinkFormCompete = useCallback((data: RecruiterFields) => {
    dispatch(setRecruiterData(data));
    if (data.recruiterId) {
      navigate('/rate');
    }
  }, []);

  return (
    <div css={classes.root}>
      {!recruiterData && <RecruiterLinkForm onComplete={handleLinkFormCompete} />}
      {recruiterData && !targetRecruiter && (
        <RecruiterPersonForm  />
      )}
    </div>
  );
};
export default Recruiter;
