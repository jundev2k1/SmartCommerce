// Copyright (c) 2024 - Jun Dev. All rights reserved
import EmailOutlinedIcon from '@mui/icons-material/EmailOutlined';
import MapOutlinedIcon from '@mui/icons-material/MapOutlined';
import PhoneAndroidOutlinedIcon from '@mui/icons-material/PhoneAndroidOutlined';

import { Avatar, Container, Grid, Link, Stack, Typography } from '../../common';

const FooterInformationComponent = () => {
  return (
    <section className="footerInformation">
      <Container>
        <Grid container spacing={2}>
          <Grid className="footerInformation__pageInfo" item md={4} sm={6}>
            <Stack spacing={1}>
              <div className="footerInformation__pageInfo__item">
                <img width="50%" src="/logo512.png" />
              </div>
              <div className="footerInformation__pageInfo__item">
                <Stack direction="row" alignItems="center" spacing={1}>
                  <Avatar
                    className="footerInformation__pageInfo__item_icon"
                    color="white"
                  >
                    <MapOutlinedIcon fontSize="small" />
                  </Avatar>
                  <Typography variant="body2">
                    Thuan giao, Thuan An, Binh Duong
                  </Typography>
                </Stack>
              </div>
              <div className="footerInformation__pageInfo__item">
                <Stack direction="row" alignItems="center" spacing={1}>
                  <Avatar
                    className="footerInformation__pageInfo__item_icon"
                    color="white"
                  >
                    <PhoneAndroidOutlinedIcon fontSize="small" />
                  </Avatar>
                  <Typography variant="body2">0969 7 333 25</Typography>
                </Stack>
              </div>
              <div className="footerInformation__pageInfo__item">
                <Stack direction="row" alignItems="center" spacing={1}>
                  <Avatar
                    className="footerInformation__pageInfo__item_icon"
                    color="white"
                  >
                    <EmailOutlinedIcon fontSize="small" />
                  </Avatar>
                  <Typography variant="body2">jun.dev2001@gmail.com</Typography>
                </Stack>
              </div>
            </Stack>
          </Grid>
          <Grid className="footerInformation__siteMap" item md={2} sm={6}>
            <Typography variant="h3">Other Link</Typography>
            <ul className="footerInformation__siteMap__list">
              <li className="footerInformation__siteMap__list__item">
                <Link href="#" underline="none">
                  Link A
                </Link>
              </li>
              <li className="footerInformation__siteMap__list__item">
                <Link href="#" underline="none">
                  Link B
                </Link>
              </li>
              <li className="footerInformation__siteMap__list__item">
                <Link href="#" underline="none">
                  Link C
                </Link>
              </li>
            </ul>
          </Grid>
          <Grid className="footerInformation__otherLink" item md={2} sm={12}>
            <Typography variant="h3">Site Map</Typography>
            <ul className="footerInformation__siteMap__list">
              <li className="footerInformation__siteMap__list__item">
                <Link href="#" underline="none">
                  Link A
                </Link>
              </li>
              <li className="footerInformation__siteMap__list__item">
                <Link href="#" underline="none">
                  Link B
                </Link>
              </li>
              <li className="footerInformation__siteMap__list__item">
                <Link href="#" underline="none">
                  Link C
                </Link>
              </li>
            </ul>
          </Grid>
          <Grid className="footerInformation__social" item md={4} sm={12}>
            <Typography variant="h3">Subscribe to our Newsletter</Typography>
          </Grid>
        </Grid>
      </Container>
    </section>
  );
};

export default FooterInformationComponent;
