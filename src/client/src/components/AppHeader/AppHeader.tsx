/** @jsxImportSource @emotion/react */
import { css } from '@emotion/react';
import Logo from '../../assets/images/ghost.png';

const classes = {
  root: css({
    display: 'flex',
  }),
  titleWrapper:css({
    width: "100%",
  }),
  title: css({
    width: 'calc(100% - 85px)',
    textAlign: "center",
  }),
  logo: css({
    width: 85,
    height: 100,
  }),
};
const AppHeader = () => {
  return (
    <div css={classes.root}>
      <a href="/">
        <img css={classes.logo} src={Logo} />
      </a>
      <div css={classes.titleWrapper}>
      <h1 css={classes.title}>Hold Recruiter Accountable Test</h1>
      </div>
    </div>
  );
};
export default AppHeader;
