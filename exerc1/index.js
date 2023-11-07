const crypto = require('crypto');

const secretKey = "#modalGR#GPTW#top#maiorEmpresaTecnologia#baixadaSantista";

const encrypt = (password) => {
  if (password.length <= 8) {
      return crypto.createHmac('sha256', secretKey).update(password).digest('hex');
  }else if (password.length > 8 && password.length <= 12) {
    return crypto.createCipheriv('aes-256-cbc', secretKey, iv).update(password,'utf-8', 'hex').final('hex');
}else{
    return crypto.createHmac('sha512', secretKey).update(password).digest('hex');
}};

const password1 = 'pass123';
const password2 = 'securePassword567';
const password3 = 'veryStrongPassword!';

const encryptedPassword1 = encrypt(password1);
const encryptedPassword2 = encrypt(password2);
const encryptedPassword3 = encrypt(password3);

console.log('Encrypted Password 1:', encryptedPassword1);
console.log('Encrypted Password 2:', encryptedPassword2);
console.log('Encrypted Password 3:', encryptedPassword3);