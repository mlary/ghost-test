/** @jsxImportSource @emotion/react */
import { css } from '@emotion/react';
import { Button } from '@mui/material';
import { useNavigate } from 'react-router';
import Logo from '../../assets/images/ghost.png';

const classes = {
  root: css({
    display: 'flex',
    justifyContent: 'space-between',
  }),
  titleWrapper: css({
    width: '100%',
  }),
  title: css({
    width: 'calc(100% - 85px)',
    textAlign: 'center',
  }),
  logo: css({
    width: 51,
    height: 60,
  }),
  singInBtn: css({
    background: '#fff',
    color: '#000',
    margin: 8,
    width: 100,
    height: 30,
    fontWeight: 600,
  }),
};
const AppHeader = () => {
  const navigate = useNavigate();
  const handleSignInClick = () => {
    navigate('/Login');
  };
  return (
    <div css={classes.root}>
      <a href="/">
        <img css={classes.logo} src={Logo} />
      </a>
      <div css={classes.titleWrapper}>
        <h1 css={classes.title}>Hold Recruiter Accountable</h1>
      </div>
      <Button css={classes.singInBtn} onClick={handleSignInClick}>
        Sign In
      </Button>
    </div>
  );
};
export default AppHeader;
