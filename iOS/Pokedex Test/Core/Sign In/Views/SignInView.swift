//
//  SignInView.swift
//  Pokedex Test
//
//  Created by Martin on 04/11/23.
//

import SwiftUI

struct SignInView: View {
    @StateObject private var viewModel = SigninViewModel()
    @State private var showSuccessView = false
    @State private var isShowingPassword = false

    
    
    var body: some View {
        NavigationStack {
            VStack {
                Spacer()
                //Logo Image
                Image("pkebtn")
                    .resizable()
                    .scaledToFit()
                    .frame(width: 150, height: 150)
                    .padding(.bottom)
                //TextFields
                VStack {
                    Text("E-mail")
                        .font(.headline)
                        .fontWeight(.bold)
                        .padding(.leading, 52)
                        .frame(maxWidth: .infinity, alignment: .leading)
                    HStack {
                        Image(systemName: "envelope")
                            .fontWeight(.bold)
                        
                        TextField("email", text: $viewModel.email)
                            .autocapitalization(.none)
                            .font(.subheadline)
                    }
                    .padding(.horizontal,52)
                    RoundedRectangle(cornerRadius: 5)
                        .frame(width: (UIScreen.main.bounds.width/2)+90,height: 1.8)
                }
                .foregroundColor(.red)
                .accentColor(.red)
                
                VStack {
                    Text("Password")
                        .font(.headline)
                        .fontWeight(.bold)
                        .padding(.leading, 52)
                        .frame(maxWidth: .infinity, alignment: .leading)
                    HStack {
                        Image(systemName: "lock")
                            .fontWeight(.bold)
                        
                        if isShowingPassword {
                            TextField("password", text: $viewModel.password)
                                .autocapitalization(.none)
                                .font(.subheadline)
                        } else {
                            SecureField("password", text: $viewModel.password)
                                .autocapitalization(.none)
                                .font(.subheadline)
                        }
                        
                        Button {
                            isShowingPassword.toggle()
                        } label: {
                            Image(systemName: "eye")
                                .fontWeight(.bold)
                        }

                        
                    }
                    .padding(.horizontal,52)
                    RoundedRectangle(cornerRadius: 5)
                        .frame(width: (UIScreen.main.bounds.width/2)+90,height: 1.8)
                }
                .foregroundColor(.red)
                .accentColor(.red)
                
                Button {
                    print("Forgot Password")
                } label: {
                    Text("Forgot Pasword?")
                        .font(.footnote)
                        .fontWeight(.bold)
                        .padding(.trailing,52)
                }
                .frame(maxWidth: .infinity, alignment: .trailing)
                .foregroundColor(.red)
                
                //Button "Sign In"
                Button {
                    Task {
                        Task {try await viewModel.loginUser()}
                    }
                } label: {
                    Text("Sign in")
                        .font(.title3)
                        .fontWeight(.semibold)
                        .foregroundColor(.white)
                        .frame(width: 158, height: 50)
                        .background(.red)
                        .cornerRadius(15)
                }
                .padding(.vertical)
                //Don't have an account <- Text
                
                Text("Don't have an account")
                    .foregroundColor(.red)
                    .font(.subheadline)
                
                //Sign Up <- Btn
                NavigationLink {
                    SignUpView()
                        
                } label: {
                    HStack(spacing: 3) {
                        Text("Sign Up")
                            .fontWeight(.bold)
                    }
                    .font(.title3)
                    .padding(.top,0.2)
                    .foregroundColor(.red)
                }
                
                Spacer()
            }
        }
    }
}

struct SignInView_Previews: PreviewProvider {
    static var previews: some View {
        SignInView()
    }
}

