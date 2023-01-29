/*!
  \page PageMaintenance Maintenance
  \tableofcontents
  \section SectionServerMaintenance Server
  \subsection SubsectionCertificate LetsEncrypt Certificate
  Mirror web transport requires SSL. The certificate used is the same used for the website, which is a "Let's Encrypt" certificate. These certificates are only valid for 90 days, and are automatically renewed by the server. When this certificate is renewed, the PFX file used by the application also needs to be updated. The following is executed on the server to update the PFX file used by the app:
  \code{.cs}
  sudo -i
  cd /etc/letsencrypt/live/o8c.us/
  openssl pkcs12 -export -out cert.pfx -inkey privkey.pem -in cert.pem -certfile chain.pem
  mv ./cert.pfx /home/octo
  exit
  sudo chown -R $USER:$USER ./cert.pfx
  sudo chmod 644 ./cert.pfx
  rm ./cert/cert.pfx
  mv ./cert.pfx ./cert
  \endcode
*/
 
