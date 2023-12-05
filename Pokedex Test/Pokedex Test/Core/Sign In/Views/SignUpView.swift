//
//  SignUpView.swift
//  Pokedex Test
//
//  Created by Martin on 05/11/23.
//

import SwiftUI

struct SignUpView: View {
    @StateObject var viewModel = RegisterViewModel()
    @State private var showSuccessView = false
    @State private var isShowingPassword = false
    
    var body: some View {
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
                Text("Username")
                    .font(.headline)
                    .fontWeight(.bold)
                    .padding(.leading, 52)
                    .frame(maxWidth: .infinity, alignment: .leading)
                HStack {
                    Image(systemName: "person")
                        .fontWeight(.bold)
                    
                    TextField("username", text: $viewModel.username)
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
                        Button {
                            isShowingPassword.toggle()
                        } label: {
                            Image(systemName: "eye")
                                .fontWeight(.bold)
                        }
                    } else {
                        SecureField("password", text: $viewModel.password)
                            .autocapitalization(.none)
                            .font(.subheadline)
                        Button {
                            isShowingPassword.toggle()
                        } label: {
                            Image(systemName: "eye.slash")
                                .fontWeight(.bold)
                        }
                    }

                    
                }
                .padding(.horizontal,52)
                RoundedRectangle(cornerRadius: 5)
                    .frame(width: (UIScreen.main.bounds.width/2)+90,height: 1.8)
            }
            .foregroundColor(.red)
            .accentColor(.red)
            
            Spacer()
            
            //Button "Sign In"
            Button {
                Task {
                    Task {try await viewModel.createUser()}
                }
            } label: {
                Text("Sign Up")
                    .font(.title3)
                    .fontWeight(.semibold)
                    .foregroundColor(.white)
                    .frame(width: 158, height: 50)
                    .background(.red)
                    .cornerRadius(15)
            }
            .padding(.vertical)
            
            Spacer()
        }
    }
}

struct SignUpView_Previews: PreviewProvider {
    static var previews: some View {
        SignUpView()
    }
}
