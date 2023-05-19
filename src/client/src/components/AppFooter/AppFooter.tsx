/** @jsxImportSource @emotion/react */
import { css } from '@emotion/react';
import { Button } from '@mui/material';
import logo from '../../assets/images/ghost.png';

const classes = {
  root: css({
    display: 'flex',
    backgroundColor: '#000',
    flexDirection: 'column',
    gap: 20,
    alignItems: 'center',
    paddingBottom: 48,
    paddingTop: 16,
    marginTop: 'auto',
  }),
  links: css({
    display: 'flex',
    flexDirection: 'column',
    alignItems: 'center',
    fontSize: '1.5rem',
  }),
  logo: css({
    width: 100,
    height: 120,
  }),
  rateBtn: css({
    background: 'var(--bg-main-rate-button)',
    fontWeight: 700,
    textTransform: 'none',
    fontSize: '1.5rem',
    height: 60,
    width: 230,
    borderRadius: 10,
  }),
  copyright: css({
    color: '#fff',
    fontSize: '1.2rem',
  }),
};
const AppFooter = () => {
  return (
    <div css={classes.root}>
      <div>
        <img src={logo} css={classes.logo} />
      </div>
      <div>
        <Button href='/' css={classes.rateBtn} color="primary" variant="contained">
          Rate Recruiter
        </Button>
      </div>
      <div css={classes.links}>
        <a>Terms & Conditions</a>
        <a>Privacy Policy</a>
      </div>
      <div css={classes.copyright}>© 2022 - Ghost Look Up All rights reserved.</div>
    </div>
  );
};
export default AppFooter;
